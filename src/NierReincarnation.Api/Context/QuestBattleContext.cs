using Art.Framework.ApiNetwork.Grpc.Api.Battle;
using Art.Framework.ApiNetwork.Grpc.Api.Quest;
using Google.Protobuf;
using Google.Protobuf.Collections;
using NierReincarnation.Context.Models;
using NierReincarnation.Context.Models.Events;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Game.TurnBattle;
using NierReincarnation.Core.Dark.Game.TurnBattle.Types;
using NierReincarnation.Core.Dark.Kernel;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using QuestReward = Art.Framework.ApiNetwork.Grpc.Api.Quest.QuestReward;

namespace NierReincarnation.Context;

public class QuestBattleContext : BaseContext
{
    private readonly DarkClient _dc = new();
    private readonly StaminaContext _stamina = new();

    public event EventHandler<StartBattleEventArgs> BattleStarted;

    public event EventHandler<BeforeFinishWaveEventArgs> BeforeFinishWave;

    public event EventHandler<FinishBattleEventArgs> BattleFinished;

    internal QuestBattleContext()
    {
        _stamina.BeforeUnauthenticated += OnBeforeUnauthenticated;
        _stamina.AfterUnauthenticated += OnAfterUnauthenticated;
    }

    #region Main Quests

    public static bool HasRunningMainQuest()
    {
        var userId = CalculatorStateUser.GetUserId();
        var table = DatabaseDefine.User.EntityIUserMainQuestProgressStatusTable;

        var entry = table.FindByUserId(userId);
        if (entry == null)
            return false;

        return entry.CurrentQuestSceneId != 0 && entry.CurrentQuestFlowType == QuestFlowType.MAIN_FLOW;
    }

    public async Task<BattleResult> ExecuteMainQuest(QuestCellData quest, DataDeck deck)
    {
        // Ensure stamina
        var refilled = await RefillStamina(quest.Quest.EntityQuest.Stamina);
        if (!refilled)
            return new BattleResult(BattleStatus.OutOfStamina);

        // Start battle
        var (shouldQuit, shouldShutdown) = await StartMainBattle(quest, deck);
        if (shouldShutdown)
            return new BattleResult(BattleStatus.ForceShutdown);

        if (shouldQuit)
            return await QuitMainQuest(quest);

        // Process waves
        var waveDecks = CalculatorQuest.GetWaveDataList(quest.Quest.QuestId, out var npcId);
        for (var waveIndex = 0; waveIndex < waveDecks.Count; waveIndex++)
        {
            var waveDeck = waveDecks[waveIndex];

            // Start wave
            await StartQuestWave(deck, npcId, waveDeck);

            // Finish wave
            await FinishQuestWave(deck, npcId, waveDeck, waveIndex + 1, waveDecks.Count, quest.FieldSceneId);
        }

        // Finish battle
        var rewards = await FinishMainBattle(quest);

        return new BattleResult(BattleStatus.Win, rewards);
    }

    public async Task<BattleResult> QuitMainQuest(QuestCellData quest)
    {
        await FinishMainBattle(quest, true);
        return new BattleResult(BattleStatus.Retire);
    }

    #region Start main battle

    private async Task<(bool, bool)> StartMainBattle(QuestCellData quest, DataDeck deck)
    {
        // Update main flow scene if quest isn't cleared yet
        // HINT: Necessary if main quest was not played yet, otherwise request gets aborted
        if (!quest.IsClear)
        {
            await TryRequest(async () =>
            {
                var fieldScene = quest.Scenes.Find(x => x.QuestSceneType == QuestSceneType.FIELD);
                var fieldSceneIndex = quest.Scenes.IndexOf(fieldScene);
                if (fieldSceneIndex <= 0)
                    return new UpdateMainFlowSceneProgressResponse();

                var previousScene = quest.Scenes[fieldSceneIndex - 1];

                var sceneReq = new UpdateMainFlowSceneProgressRequest { QuestSceneId = previousScene.QuestSceneId };
                return await _dc.QuestService.UpdateMainFlowSceneProgressAsync(sceneReq);
            });
        }

        // Start battle
        var startRes = await TryRequest(async () =>
          {
              var startReq = GetStartMainBattleRequest(quest.Quest.QuestId, quest.DifficultyType == DifficultyType.NORMAL && !quest.IsClear, deck.UserDeckNumber);
              return await _dc.QuestService.StartMainQuestAsync(startReq);
          });

        if (startRes == null)
            return (false, true);

        // Update main quest progress
        await TryRequest(async () =>
        {
            var progressReq = new UpdateMainQuestSceneProgressRequest { QuestSceneId = quest.FieldSceneId };
            return await _dc.UpdateMainQuestSceneProgressAsync(progressReq);
        });

        OnStartBattle(startRes.BattleDropReward, out var retire, out var shutdown);

        return (retire, shutdown);
    }

    // TODO: Add replay flow for replay rewards
    private static StartMainQuestRequest GetStartMainBattleRequest(int questId, bool isMainFlowRequired, int deckNumber)
    {
        var result = new StartMainQuestRequest
        {
            QuestId = questId,
            UserDeckNumber = deckNumber,

            IsMainFlow = isMainFlowRequired,
            IsBattleOnly = !isMainFlowRequired,

            CageMeasurableValues = new CageMeasurableValues(),
        };

        return result;
    }

    #endregion Start main battle

    #region Finish main battle

    private async Task<BattleDrops> FinishMainBattle(QuestCellData quest, bool retire = false)
    {
        // Finish battle
        var finishRes = await TryRequest(async () =>
        {
            var finishReq = GetFinishMainBattleRequest(quest.Quest.QuestId, quest.IsStoryQuest, quest.DifficultyType == DifficultyType.NORMAL && !quest.IsClear, retire);
            return await _dc.QuestService.FinishMainQuestAsync(finishReq);
        });

        if (finishRes == null)
            return BattleDrops.Empty;

        var rewards = CreateBattleDrops(finishRes.DropReward, finishRes.FirstClearReward, finishRes.MissionClearCompleteReward, finishRes.MissionClearReward);
        OnFinishBattle(rewards);

        return rewards;
    }

    private static FinishMainQuestRequest GetFinishMainBattleRequest(int questId, bool isStoryQuest, bool isMainFlowRequired, bool retire)
    {
        var result = new FinishMainQuestRequest
        {
            QuestId = questId,

            IsRetired = retire, // Retire battle; Loses stamina
            IsMainFlow = isMainFlowRequired,
            IsAutoOrbit = false,

            Vt = DarkClient.CreateVerifierToken()
        };

        if (!retire)
            result.IsAnnihilated = false;

        // If quest has a story part, we set the skip type accordingly
        if (isStoryQuest)
        {
            result.StorySkipType = isMainFlowRequired ?
                (int)QuestStorySkipType.SKIP_PICTURE_BOOK_IN_MAIN_FLOW :
                (int)QuestStorySkipType.SKIP_BY_BATTLE_ONLY_IN_SUB_FLOW;
        }

        return result;
    }

    #endregion Finish main battle

    #endregion Main Quests

    #region Event Quests

    public static bool HasRunningEventQuest()
    {
        var userId = CalculatorStateUser.GetUserId();
        var table = DatabaseDefine.User.EntityIUserEventQuestProgressStatusTable;

        var entry = table.FindByUserId(userId);
        if (entry == null)
            return false;

        return entry.CurrentEventQuestChapterId != 0;
    }

    public Task<BattleResult> ExecuteEventQuest(int chapterId, LimitDailyQuestData quest, DataDeck deck)
    {
        return ExecuteEventQuest(chapterId, quest.Quest.EntityQuest.Stamina, quest.Quest.QuestId, quest.SceneId, deck);
    }

    public Task<BattleResult> ExecuteEventQuest(int chapterId, EventQuestData quest, DataDeck deck)
    {
        return ExecuteEventQuest(chapterId, quest.Quest.EntityQuest.Stamina, quest.Quest.QuestId, quest.SceneId, deck);
    }

    private async Task<BattleResult> ExecuteEventQuest(int chapterId, int stamina, int questId, int sceneId, DataDeck deck)
    {
        // Ensure stamina
        var refilled = await RefillStamina(stamina);
        if (!refilled)
            return new BattleResult(BattleStatus.OutOfStamina);

        // Start battle
        var (shouldQuit, shouldShutdown) = await StartEventBattle(chapterId, questId, sceneId, deck);
        if (shouldShutdown)
            return new BattleResult(BattleStatus.ForceShutdown);

        if (shouldQuit)
            return await QuitEventQuest(chapterId, questId);

        // Process waves
        var waveDecks = CalculatorQuest.GetWaveDataList(questId, out var npcId);
        for (var waveIndex = 0; waveIndex < waveDecks.Count; waveIndex++)
        {
            var waveDeck = waveDecks[waveIndex];

            // Start wave
            await StartQuestWave(deck, npcId, waveDeck);

            // Finish wave
            await FinishQuestWave(deck, npcId, waveDeck, waveIndex + 1, waveDecks.Count, sceneId);
        }

        // Finish battle
        var rewards = await FinishEventBattle(chapterId, questId);

        return new BattleResult(BattleStatus.Win, rewards);
    }

    public async Task<BattleResult> QuitEventQuest(int chapterId, int questId)
    {
        await FinishEventBattle(chapterId, questId, true);
        return new BattleResult(BattleStatus.Retire);
    }

    #region Start event battle

    private async Task<(bool, bool)> StartEventBattle(int chapterId, int questId, int sceneId, DataDeck deck)
    {
        // Start battle
        var startRes = await TryRequest(async () =>
        {
            var startReq = GetStartEventBattleRequest(chapterId, questId, deck.UserDeckNumber);
            return await _dc.QuestService.StartEventQuestAsync(startReq);
        });

        if (startRes == null)
            return (false, true);

        // Update quest progress
        await TryRequest(async () =>
        {
            var progressReq = new UpdateEventQuestSceneProgressRequest { QuestSceneId = sceneId };
            return await _dc.UpdateEventQuestSceneProgressAsync(progressReq);
        });

        OnStartBattle(startRes.BattleDropReward, out var retire, out var shutdown);

        return (retire, shutdown);
    }

    private static StartEventQuestRequest GetStartEventBattleRequest(int chapterId, int questId, int deckNumber)
    {
        var req = new StartEventQuestRequest
        {
            EventQuestChapterId = chapterId,
            QuestId = questId,
            UserDeckNumber = deckNumber,
            // Max auto battles, IF auto is activated. We disallow this here.
            // HINT: Original logic used CalculatorQuest.GetMaxAutoOrbitCount()
            //MaxAutoOrbitCount = 1
        };

        // We're always battle-only, instead of special quests, where this option would result in an exception
        var type = CalculatorEventQuest.GetEventQuestTypeByChapterId(chapterId);
        if (type != EventQuestType.SPECIAL)
            req.IsBattleOnly = true;

        return req;
    }

    #endregion Start event battle

    #region Finish event battle

    private async Task<BattleDrops> FinishEventBattle(int chapterId, int questId, bool retire = false)
    {
        // Finish battle
        var finishRes = await TryRequest(async () =>
        {
            var finishReq = GetFinishEventBattleRequest(chapterId, questId, retire);
            return await _dc.QuestService.FinishEventQuestAsync(finishReq);
        });

        if (finishRes == null)
            return BattleDrops.Empty;

        var rewards = CreateBattleDrops(finishRes.DropReward, finishRes.FirstClearReward, finishRes.MissionClearCompleteReward, finishRes.MissionClearReward);
        OnFinishBattle(rewards);

        return rewards;
    }

    private static FinishEventQuestRequest GetFinishEventBattleRequest(int chapterId, int questId, bool retire)
    {
        return new FinishEventQuestRequest
        {
            EventQuestChapterId = chapterId,
            QuestId = questId,

            IsAnnihilated = false,  // Indicator if battle was won
            IsAutoOrbit = false,    // If battle is part of an auto battler in-game
            IsRetired = retire,  // Retire battle; Loses stamina

            StorySkipType = (int)QuestStorySkipType.SKIP_BY_BATTLE_ONLY_IN_SUB_FLOW,

            Vt = DarkClient.CreateVerifierToken()
        };
    }

    #endregion Finish event battle

    #endregion Event Quests

    #region Extra Quests

    public static bool HasRunningExtraQuest()
    {
        var userId = CalculatorStateUser.GetUserId();
        var table = DatabaseDefine.User.EntityIUserExtraQuestProgressStatusTable;

        var entry = table.FindByUserId(userId);
        if (entry == null)
            return false;

        return entry.CurrentQuestId != 0;
    }

    public async Task<BattleResult> ExecuteExtraQuest(EntityMQuest quest, DataDeck deck)
    {
        var questId = quest.QuestId;
        var sceneId = CalculatorQuest.CreateQuestFieldSceneList(questId).FirstOrDefault()?.QuestSceneId ?? 0;

        // Ensure stamina
        var refilled = await RefillStamina(quest.Stamina);
        if (!refilled)
            return new BattleResult(BattleStatus.OutOfStamina);

        // Start battle
        var (shouldQuit, shouldShutdown) = await StartExtraBattle(questId, deck);
        if (shouldShutdown)
            return new BattleResult(BattleStatus.ForceShutdown);

        if (shouldQuit)
            return await QuitExtraQuest(questId);

        // Process waves
        var waveDecks = CalculatorQuest.GetWaveDataList(questId, out var npcId);
        for (var waveIndex = 0; waveIndex < waveDecks.Count; waveIndex++)
        {
            var waveDeck = waveDecks[waveIndex];

            // Start wave
            await StartQuestWave(deck, npcId, waveDeck);

            // Finish wave
            await FinishQuestWave(deck, npcId, waveDeck, waveIndex + 1, waveDecks.Count, sceneId);
        }

        // Finish battle
        var rewards = await FinishExtraBattle(questId);

        return new BattleResult(BattleStatus.Win, rewards);
    }

    public async Task<BattleResult> QuitExtraQuest(int questId)
    {
        await FinishExtraBattle(questId, true);
        return new BattleResult(BattleStatus.Retire);
    }

    #region Start extra battle

    private async Task<(bool, bool)> StartExtraBattle(int questId, DataDeck deck)
    {
        // Start battle
        var startRes = await TryRequest(async () =>
        {
            var startReq = GetStartExtraBattleRequest(questId, deck.UserDeckNumber);
            return await _dc.QuestService.StartExtraQuestAsync(startReq);
        });

        if (startRes == null)
            return (false, true);

        OnStartBattle(startRes.BattleDropReward, out var retire, out var shutdown);

        return (retire, shutdown);
    }

    private static StartExtraQuestRequest GetStartExtraBattleRequest(int questId, int deckNumber)
    {
        return new StartExtraQuestRequest
        {
            QuestId = questId,
            UserDeckNumber = deckNumber
        };
    }

    #endregion Start extra battle

    #region Finish extra battle

    private async Task<BattleDrops> FinishExtraBattle(int questId, bool retire = false)
    {
        // Finish battle
        var finishRes = await TryRequest(async () =>
        {
            var finishReq = GetFinishExtraBattleRequest(questId, retire);
            return await _dc.QuestService.FinishExtraQuestAsync(finishReq);
        });

        if (finishRes == null)
            return BattleDrops.Empty;

        var rewards = CreateBattleDrops(finishRes.DropReward, finishRes.FirstClearReward, finishRes.MissionClearCompleteReward, finishRes.MissionClearReward);
        OnFinishBattle(rewards);

        return rewards;
    }

    private static FinishExtraQuestRequest GetFinishExtraBattleRequest(int questId, bool retire)
    {
        return new FinishExtraQuestRequest
        {
            QuestId = questId,

            IsAnnihilated = false,  // Indicator if battle was won
            IsRetired = retire,  // Retire battle; Loses stamina

            StorySkipType = (int)QuestStorySkipType.SKIP_BY_BATTLE_ONLY_IN_SUB_FLOW,

            Vt = DarkClient.CreateVerifierToken()
        };
    }

    #endregion Finish extra battle

    #endregion Extra Quests

    #region Refill stamina

    private Task<bool> RefillStamina(int reqStamina)
    {
        return TryRequest(async () =>
        {
            var currentStamina = StaminaContext.GetCurrentStamina();
            if (currentStamina < reqStamina)
                return await _stamina.RefillStamina(reqStamina);

            return true;
        });
    }

    #endregion Refill stamina

    #region Start wave

    private async Task StartQuestWave(DataDeck deck, long npcId, DataDeck waveDeck)
    {
        await TryRequest(async () =>
        {
            var startWaveReq = GetStartWaveRequest(deck, npcId, waveDeck);
            return await _dc.BattleService.StartWaveAsync(startWaveReq);
        });
    }

    private static StartWaveRequest GetStartWaveRequest(DataDeck deck, long npcId, DataDeck npcDeck)
    {
        return new StartWaveRequest
        {
            UserPartyInitialInfoList =
            {
                new UserPartyInitialInfo
                {
                    UserId = ApplicationScopeClientContext.Instance.User.UserId,
                    DeckType = (int) deck.DeckType,
                    UserDeckNumber = deck.UserDeckNumber,
                    TotalHp = deck.UserDeckActors.Sum(a => a?.StatusValue.Hp ?? 0),
                    Vt = DarkClient.CreateVerifierToken()
                }
            },
            NpcPartyInitialInfoList =
            {
                new NpcPartyInitialInfo
                {
                    NpcId = npcId,
                    DeckType = (int) npcDeck.DeckType,
                    BattleNpcDeckNumber = npcDeck.UserDeckNumber,
                    TotalHp = npcDeck.UserDeckActors.Sum(a => a?.StatusValue.Hp ?? 0)
                }
            }
        };
    }

    #endregion Start wave

    #region Finish wave

    private async Task FinishQuestWave(DataDeck deck, long npcId, DataDeck waveDeck, int wave, int waveCount, int sceneId)
    {
        await TryRequest(async () =>
        {
            var finishWaveReq = GetFinishWaveRequest(deck, npcId, waveDeck, wave, waveCount, sceneId);
            OnBeforeFinishWave(wave, waveCount, finishWaveReq.BattleDetail);
            return await _dc.BattleService.FinishWaveAsync(finishWaveReq);
        });
    }

    private FinishWaveRequest GetFinishWaveRequest(DataDeck deck, long npcId, DataDeck npcDeck, int wave, int waveCount, int sceneId)
    {
        var battleDetail = GetQuestBattleDetail(deck, npcDeck);

        var battleSnapshot = CreateBattleSnapshot(deck, wave, waveCount, sceneId);
        var battleBinary = CalculatorBattleBinary.CreateBattleBinary(battleSnapshot, ContextApi.ActiveContext.Thread.Source.Token, out var binarySize);

        return new FinishWaveRequest
        {
            BattleBinary = ByteString.CopyFrom(battleBinary, 0, binarySize),
            BattleDetail = battleDetail,
            UserPartyResultInfoList = { GetUserPartyInfo(deck, npcId, npcDeck) },
            NpcPartyResultInfoList = { GetNpcPartyInfo(deck, npcId, npcDeck) },
            ElapsedFrameCount = 390,

            Vt = DarkClient.CreateVerifierToken()
        };
    }

    #endregion Finish wave

    #region Support

    private static BattleDrops CreateBattleDrops(RepeatedField<QuestReward> drops, RepeatedField<QuestReward> firstClear, RepeatedField<QuestReward> missionClearComplete, RepeatedField<QuestReward> missionClear)
    {
        var dropRewards = drops.Select(x => new Models.QuestReward(x)).ToArray();
        var firstClearRewards = firstClear.Select(x => new Models.QuestReward(x)).ToArray();
        var missionCompleteRewards = missionClearComplete.Select(x => new Models.QuestReward(x)).ToArray();
        var missionRewards = missionClear.Select(x => new Models.QuestReward(x)).ToArray();

        return new BattleDrops(dropRewards, firstClearRewards, missionCompleteRewards, missionRewards);
    }

    private BattleDetail GetQuestBattleDetail(DataDeck deck, DataDeck npcDeck)
    {
        var dmgInfo = GetDamageInfo(deck, npcDeck);

        var result = new BattleDetail
        {
            MaxDamage = dmgInfo.Item1
        };

        for (var i = 0; i < deck.UserDeckActors.Length; i++)
        {
            var actor = deck.UserDeckActors[i];
            if (actor == null)
                continue;

            result.CostumeBattleInfo.Add(new CostumeBattleInfo
            {
                DeckCharacterNumber = i + 1,
                TotalDamage = dmgInfo.Item2[i].Item2,
                IsAlive = true,
                HitCount = dmgInfo.Item2[i].Item1,
                MaxHp = actor.StatusValue.Hp,
                RemainingHp = actor.StatusValue.Hp,

                UserDeckNumber = deck.UserDeckNumber
            });
        }

        return result;
    }

    private static (int, (int, int)[]) GetDamageInfo(DataDeck deck, DataDeck npcDeck)
    {
        // Cycle through characters to create a balanced attack distribution
        var npcActorHp = npcDeck.UserDeckActors.Select(x => x?.StatusValue.Hp ?? 0).Where(x => x > 0).ToList();

        int maxDamage = 0;
        var result = new (int, int)[3];

        var index = 0;
        while (npcActorHp.Count > 0)
        {
            var localIndex = index++ % 3;
            var actor = deck.UserDeckActors[localIndex];

            if (actor == null)
                continue;

            if (maxDamage < actor.StatusValue.Attack)
                maxDamage = actor.StatusValue.Attack;

            result[localIndex] = (result[localIndex].Item1 + 1, result[localIndex].Item2 + actor.StatusValue.Attack);
            npcActorHp[0] -= actor.StatusValue.Attack;

            if (npcActorHp[0] <= 0)
                npcActorHp.RemoveAt(0);
        }

        return (maxDamage, result);
    }

    private static TurnBattleSnapshot CreateBattleSnapshot(DataDeck deck, int wave, int waveCount, int sceneId)
    {
        var partyHash = new PartyHash(TeamHash.OwnTeamHash, wave - 1);

        var snapshot = new TurnBattleSnapshot
        {
            TurnBattleSnapshotVersion = BattleProgressDataDefinition.kTurnBattleSnapshotVersion,
            BattleSnapshot = new TurnBattleBattleSnapshot
            {
                SceneId = sceneId,
                ProgressDataKey = TurnBattleBattleSnapshot.GenerateProgressDataKey(sceneId),

                CurrentPlayerDeckPartyHash = partyHash,

                WaveNumber = wave,
                WaveCapacity = waveCount,

                EndType = 1,
                GameSpeedType = 1,
                IsAuto = false
            }
        };

        foreach (var actor in deck.UserDeckActors)
        {
            if (actor == null)
                continue;

            var actorHash = CalculatorActor.CreateActorHash(partyHash, 1);

            snapshot.ActorSnapshots.Add(new TurnBattleActorSnapshot
            {
                ActorHash = actorHash,
                ProgressDataKey = TurnBattleActorSnapshot.GenerateProgressDataKey(actorHash, wave),

                IsAlive = true,
                IsActive = true,
                IsFaint = false,

                DynamicAgility = actor.StatusValue.Agility,
                DynamicAttack = actor.StatusValue.Attack,
                DynamicCriticalAttack = actor.StatusValue.CriticalAttack,
                DynamicCriticalRatio = actor.StatusValue.CriticalRatio,
                DynamicEvasionRatio = actor.StatusValue.EvasionRatio,
                DynamicHp = actor.StatusValue.Hp,
                DynamicVitality = actor.StatusValue.Vitality,
                DynamicHateValue = 1000,

                DynamicCurrentHp = actor.StatusValue.Hp
            });
        }

        return snapshot;
    }

    private UserPartyResultInfo GetUserPartyInfo(DataDeck deck, long npcId, DataDeck npcDeck)
    {
        var dmgInfo = GetDamageInfo(deck, npcDeck);

        var result = new UserPartyResultInfo
        {
            UserId = ApplicationScopeClientContext.Instance.User.UserId,
            DeckType = (int)deck.DeckType,
            UserDeckNumber = deck.UserDeckNumber,

            AddDamageInfoList =
            {
                new AddUserDamageInfo
                {
                    UserId = ApplicationScopeClientContext.Instance.User.UserId,
                    DeckType = (int)deck.DeckType,
                    DeckNumber = deck.UserDeckNumber,
                    TotalDamage = npcDeck.UserDeckActors.Sum(a => a?.StatusValue.Hp ?? 0),
                    TotalUnclampedDamage = dmgInfo.Item2.Sum(x=>x.Item2)
                },
                new AddUserDamageInfo
                {
                    UserId = npcId,
                    DeckType = (int)npcDeck.DeckType,
                    DeckNumber = npcDeck.UserDeckNumber,
                    TotalDamage = npcDeck.UserDeckActors.Sum(a => a?.StatusValue.Hp ?? 0),
                    TotalUnclampedDamage = dmgInfo.Item2.Sum(x=>x.Item2)
                }
            }
        };

        for (var j = 0; j < 2; j++)
        {
            for (var i = 0; i < deck.UserDeckActors.Length; i++)
            {
                var actor = deck.UserDeckActors[i];
                if (actor == null)
                    continue;

                foreach (var skill in actor.MainWeapon.Skills)
                {
                    var mainWeaponSkillDetail = CalculatorMasterData.GetEntityMSkillDetail(skill.SkillId, skill.SkillLevel);
                    result.SkillUseInfo.Add(new SkillUseInfo
                    {
                        DeckCharacterUuid = actor.UserDeckActorUuid,
                        SkillDetailId = mainWeaponSkillDetail.SkillDetailId
                    });
                }

                var activeSkillDetail = CalculatorMasterData.GetEntityMSkillDetail(actor.Costume.CostumeActiveSkill.SkillId, actor.Costume.CostumeActiveSkill.SkillLevel);
                result.SkillUseInfo.Add(new SkillUseInfo
                {
                    DeckCharacterUuid = actor.UserDeckActorUuid,
                    SkillDetailId = activeSkillDetail.SkillDetailId
                });

                result.SkillUseInfo.Add(new SkillUseInfo
                {
                    DeckCharacterUuid = actor.UserDeckActorUuid,
                    SkillDetailId = 999999,
                    UseCount = dmgInfo.Item2[i].Item1
                });
            }
        }

        return result;
    }

    private static NpcPartyResultInfo GetNpcPartyInfo(DataDeck deck, long npcId, DataDeck npcDeck)
    {
        var result = new NpcPartyResultInfo
        {
            NpcId = npcId,
            DeckType = (int)npcDeck.DeckType,
            BattleNpcDeckNumber = npcDeck.UserDeckNumber,

            AddDamageInfoList =
            {
                new AddNpcDamageInfo
                {
                    NpcId = ApplicationScopeClientContext.Instance.User.UserId,
                    DeckType = (int)deck.DeckType,
                    DeckNumber = deck.UserDeckNumber,
                    TotalDamage = 0
                },
                new AddNpcDamageInfo
                {
                    NpcId = npcId,
                    DeckType = (int)npcDeck.DeckType,
                    DeckNumber = npcDeck.UserDeckNumber,
                    TotalDamage = 0
                }
            },

            CharacterHpDepletedCount = npcDeck.UserDeckActors.Count(x => x != null)
        };

        for (var j = 0; j < 2; j++)
        {
            foreach (var actor in npcDeck.UserDeckActors)
            {
                if (actor == null)
                    continue;

                foreach (var skill in actor.MainWeapon.Skills)
                {
                    var mainWeaponSkillDetail = CalculatorMasterData.GetEntityMSkillDetail(skill.SkillId, skill.SkillLevel);
                    result.SkillUseInfo.Add(new SkillUseInfo
                    {
                        DeckCharacterUuid = actor.UserDeckActorUuid,
                        SkillDetailId = mainWeaponSkillDetail.SkillDetailId
                    });
                }

                if (actor.Costume.CostumeActiveSkill == null)
                    continue;

                var activeSkillDetail = CalculatorMasterData.GetEntityMSkillDetail(actor.Costume.CostumeActiveSkill.SkillId, actor.Costume.CostumeActiveSkill.SkillLevel);
                result.SkillUseInfo.Add(new SkillUseInfo
                {
                    DeckCharacterUuid = actor.UserDeckActorUuid,
                    SkillDetailId = activeSkillDetail.SkillDetailId
                });
            }
        }

        return result;
    }

    #endregion Support

    private void OnStartBattle(RepeatedField<BattleDropReward> dropRewards, out bool retire, out bool shutdown)
    {
        var args = new StartBattleEventArgs(dropRewards.Select(x => (RewardCategory)x.BattleDropEffectId).ToArray());
        BattleStarted?.Invoke(this, args);

        retire = args.ShouldQuitBattle;
        shutdown = args.ForceShutdown;
    }

    private void OnBeforeFinishWave(int waveNumber, int waveCount, BattleDetail detail)
    {
        var args = new BeforeFinishWaveEventArgs(waveNumber, waveCount, detail);
        BeforeFinishWave?.Invoke(this, args);
    }

    private void OnFinishBattle(BattleDrops rewards)
    {
        var args = new FinishBattleEventArgs(rewards);
        BattleFinished?.Invoke(this, args);
    }
}
