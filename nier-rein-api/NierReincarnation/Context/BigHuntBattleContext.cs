using System;
using System.Linq;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Battle;
using Art.Framework.ApiNetwork.Grpc.Api.BigHunt;
using Google.Protobuf;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Game.TurnBattle;
using NierReincarnation.Core.Dark.Game.TurnBattle.Types;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Kernel;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace NierReincarnation.Context
{
    public class BigHuntBattleContext: BaseContext
    {
        private const int BigHuntBasePermil_ = 1000;
        private const int BigHuntMaxSurvivalPermil_ = 2000;
        private const int BigHuntMaxComboPermil_ = 1400;
        private const int BigHuntMaxCombo_ = 42;

        private const int BaseKnockdownPermil_ = 4000;

        private static readonly int[] WaveKnockdownModifierPermil = { 0, 250, 500 };
        private static readonly int[] DifficultyKnockdownModifierPermil = { 0, 1000, 2000, 3000 };

        private readonly Random _random = new Random();
        private readonly DarkClient _dc = new DarkClient();

        internal BigHuntBattleContext() { }

        public static bool HasRunningBigHuntQuest()
        {
            var userId = CalculatorStateUser.GetUserId();
            var table = DatabaseDefine.User.EntityIUserBigHuntProgressStatusTable;

            return table.FindByUserId(userId)?.CurrentQuestSceneId != 0;
        }

        public async Task<BigHuntBattleStatus> ExecuteBigHuntQuest(BigHuntQuestData quest, int bigHuntDeckNumber, SubjugationGrade grade)
        {
            // Check if grade and resulting total damage is valid
            var totalDmg = GetGradeDamage(grade, quest.DifficultyBonusPermilValue);
            if (totalDmg < 0)
                return BigHuntBattleStatus.Aborted;

            // Start big hunt battle
            await StartBigHuntBattle(quest, bigHuntDeckNumber);

            // Execute waves
            var userDecks = CalculatorDeck.CreateTripleWaveDataDeck(CalculatorStateUser.GetUserId(), DeckType.BIG_HUNT, bigHuntDeckNumber);
            var npcDecks = CalculatorQuest.GetWaveDataList(quest.Quest.QuestId, out var npcId);

            var sceneId = CalculatorQuest.CreateQuestFieldSceneList(quest.Quest.QuestId)[0].QuestSceneId;

            var difficultyKnockdownPermil = DifficultyKnockdownModifierPermil[quest.SortOrder - 1];
            var deckDmg = GetDeckDamage(userDecks, totalDmg);
            var localDmg = 0L;

            for (var wave = 0; wave < CalculatorDeck.kTripleDeckWaveCount; wave++)
            {
                var userDeck = userDecks[wave];
                var npcDeck = npcDecks[wave];

                localDmg += deckDmg[wave];
                await FinishBigHuntWave(userDeck, bigHuntDeckNumber, npcDeck, difficultyKnockdownPermil, deckDmg[wave], localDmg, wave + 1, CalculatorDeck.kTripleDeckWaveCount, sceneId);
            }

            // Finish big hunt battle
            await FinishBigHuntBattle(quest);

            return BigHuntBattleStatus.Win;
        }

        public async Task<BattleResult> QuitBigHuntQuest(BigHuntQuestData quest)
        {
            await FinishBigHuntBattle(quest, true);
            return new BattleResult(BattleStatus.Retire);
        }

        #region Start battle

        private async Task StartBigHuntBattle(BigHuntQuestData quest, int bigHuntDeckNumber)
        {
            await TryRequest(async () =>
            {
                var startReq = GetStartBigHuntQuestRequest(quest, bigHuntDeckNumber);
                return await _dc.BigHuntService.StartBigHuntQuestAsync(startReq);
            });
        }

        private StartBigHuntQuestRequest GetStartBigHuntQuestRequest(BigHuntQuestData quest, int bigHuntDeckNumber)
        {
            return new StartBigHuntQuestRequest
            {
                BigHuntQuestId = (quest.Quest as BigHuntQuest).EntityQuestSequence.BigHuntQuestId,
                BigHuntBossQuestId = quest.BigHuntBossQuestId,
                UserDeckNumber = bigHuntDeckNumber
            };
        }

        #endregion

        #region Finish wave

        private async Task FinishBigHuntWave(DataDeck deck, int deckNumber, DataDeck npcDeck, int difficultyKnockdownPermil, long waveDmg, long totalDmg, int wave, int waveCount, int sceneId)
        {
            await TryRequest(async () =>
            {
                var waveReq = GetSaveBigHuntBattleInfoRequest(deck, deckNumber, npcDeck, difficultyKnockdownPermil, waveDmg, totalDmg, wave, waveCount, sceneId);
                return await _dc.BigHuntService.SaveBigHuntBattleInfoAsync(waveReq);
            });
        }

        private SaveBigHuntBattleInfoRequest GetSaveBigHuntBattleInfoRequest(DataDeck userDeck, int deckNumber, DataDeck npcDeck, int difficultyKnockdownPermil, long waveDmg, long totalDmg, int wave, int waveCount, int sceneId)
        {
            var battleSnapshot = CreateBigHuntBattleSnapshot(npcDeck, totalDmg, wave, waveCount, sceneId);
            var battleBinary = CalculatorBattleBinary.CreateBattleBinary(battleSnapshot, ContextApi.ActiveContext.Thread.Source.Token, out var binarySize);

            var req = new SaveBigHuntBattleInfoRequest
            {
                BattleBinary = ByteString.CopyFrom(battleBinary, 0, binarySize),
                BigHuntBattleDetail = new BigHuntBattleDetail
                {
                    BossKnockDownCount = wave,   // As many knockdowns as their are waves
                    DeckType = (int)DeckType.BIG_HUNT,
                    MaxComboCount = wave == 1 ? BigHuntMaxCombo_ : _random.Next(0, BigHuntMaxCombo_ - 1),
                    UserTripleDeckNumber = deckNumber
                },
                ElapsedFrameCount = _random.Next(450, 1500),
                Vt = DarkClient.CreateVerifierToken()
            };

            var knockdownModifierPermil = BaseKnockdownPermil_ + difficultyKnockdownPermil + WaveKnockdownModifierPermil[wave - 1];
            var dmgInfo = GetBigHuntDamageInfo(userDeck, waveDmg, knockdownModifierPermil);
            for (var i = 0; i < userDeck.UserDeckActors.Length; i++)
            {
                var actor = userDeck.UserDeckActors[i];
                if (actor == null)
                    continue;

                req.BigHuntBattleDetail.CostumeBattleInfo.Add(new CostumeBattleInfo
                {
                    DeckCharacterNumber = i + 1,
                    TotalDamage = dmgInfo[i].Item2,
                    IsAlive = true,
                    HitCount = dmgInfo[i].Item1,
                    MaxHp = actor.StatusValue.Hp,
                    RemainingHp = actor.StatusValue.Hp,

                    UserDeckNumber = userDeck.UserDeckNumber
                });
            }

            return req;
        }

        #endregion

        #region Finish battle

        private async Task FinishBigHuntBattle(BigHuntQuestData quest, bool retire = false)
        {
            await TryRequest(async () =>
            {
                var finishReq = GetFinishBigHuntQuestRequest(quest, retire);
                return await _dc.BigHuntService.FinishBigHuntQuestAsync(finishReq);
            });
        }

        private FinishBigHuntQuestRequest GetFinishBigHuntQuestRequest(BigHuntQuestData quest, bool retire)
        {
            return new FinishBigHuntQuestRequest
            {
                BigHuntQuestId = (quest.Quest as BigHuntQuest).EntityQuestSequence.BigHuntQuestId,
                BigHuntBossQuestId = quest.BigHuntBossQuestId,
                IsRetired = retire,
                Vt = DarkClient.CreateVerifierToken()
            };
        }

        #endregion

        #region Support

        private long GetGradeDamage(SubjugationGrade grade, int difficultyPermil)
        {
            var gradeScore = GetGradeScore(grade);
            var gradePermil = (BigHuntBasePermil_ + difficultyPermil + BigHuntMaxSurvivalPermil_ + BigHuntMaxComboPermil_) / 10.0;

            var baseScore = (int)(gradeScore / gradePermil * 100);

            return baseScore * 100 + _random.Next(0, 99);
        }

        private long GetGradeScore(SubjugationGrade grade)
        {
            var gradeOrder = grade.GetOrder();
            var gradeData = DatabaseDefine.Master.EntityMBigHuntBossGradeGroupTable.All;

            if (gradeOrder < 0 || gradeData.Count <= gradeOrder)
                return -1;

            var nextGradeOrder = gradeOrder + 1;
            if (gradeData.Count <= nextGradeOrder)
                return gradeData[gradeOrder].NecessaryScore + _random.Next(0, 1000000);

            // TODO: Create long Random?
            return _random.Next((int)gradeData[gradeOrder].NecessaryScore, (int)gradeData[nextGradeOrder].NecessaryScore - 1);
        }

        private long[] GetDeckDamage(DataDeck[] userDecks, long totalDmg)
        {
            var totalPower = (double)userDecks.Sum(x => x.Power);
            var percentages = userDecks.Select(x => x.Power / totalPower);

            return percentages.Select(x => (long)(totalDmg * x)).ToArray();
        }

        private TurnBattleSnapshot CreateBigHuntBattleSnapshot(DataDeck npcDeck, long totalDmg, int wave, int waveCount, int sceneId)
        {
            var bossActor = npcDeck.UserDeckActors[0];
            var bossPartyHash = new PartyHash(TeamHash.IntercessionTeamHash, wave - 1); // HINT: Unknown why here wave is used, instead of wave - 1, as in the normal quest battle binary
            var bossActorHash = CalculatorActor.CreateActorHash(bossPartyHash, 1);

            var partyHash = new PartyHash(TeamHash.OwnTeamHash, wave);

            var snapshot = new TurnBattleSnapshot
            {
                TurnBattleSnapshotVersion = BattleProgressDataDefinition.kTurnBattleSnapshotVersion,
                BattleSnapshot = new TurnBattleBattleSnapshot
                {
                    SceneId = sceneId,
                    ProgressDataKey = TurnBattleBattleSnapshot.GenerateProgressDataKey(sceneId),

                    CurrentPlayerDeckPartyHash = partyHash,
                    CurrentGaugeValue = _random.Next(0, 1400),
                    CurrentPhaseOrder = 1,

                    BattleReportRandomDisplayType = 3,
                    CumulativeDamageValue = totalDmg,

                    WaveNumber = wave,
                    WaveCapacity = waveCount,

                    EndType = 1,
                    GameSpeedType = 1,
                    IsAuto = false
                },
                ActorSnapshots =
                {
                    new TurnBattleActorSnapshot
                    {
                        ActorHash = bossActorHash,
                        ProgressDataKey = TurnBattleActorSnapshot.GenerateProgressDataKey(bossActorHash, wave),

                        DynamicAgility = bossActor.StatusValue.Agility,
                        DynamicAttack = bossActor.StatusValue.Attack,
                        DynamicCriticalAttack = bossActor.StatusValue.CriticalAttack,
                        DynamicCriticalRatio = bossActor.StatusValue.CriticalRatio,
                        DynamicEvasionRatio = bossActor.StatusValue.EvasionRatio,
                        DynamicHp = bossActor.StatusValue.Hp,
                        DynamicVitality = bossActor.StatusValue.Vitality,
                        DynamicHateValue = 1000,

                        DynamicCurrentHp = bossActor.StatusValue.Hp,

                        IsActive = true,
                        IsAlive = true,
                        IsFaint = false,
                    }
                }
            };

            return snapshot;
        }

        private (int, long)[] GetBigHuntDamageInfo(DataDeck deck, long waveDmg, int knockdownModifierPermil)
        {
            var result = new (int, long)[3];

            var totalHits = 0;
            var knockdownHitLimit = 20;

            var index = 0;
            while (waveDmg > 0)
            {
                var localIndex = index++ % 3;
                var actor = deck.UserDeckActors[localIndex];

                if (actor == null)
                    continue;

                var actorDmg = actor.StatusValue.Attack;
                if (totalHits < knockdownHitLimit)
                    actorDmg += (int)(actorDmg * knockdownModifierPermil / 1000f);

                result[localIndex] = (result[localIndex].Item1 + 1, result[localIndex].Item2 + actorDmg);
                waveDmg -= actorDmg;

                totalHits++;
            }

            // Correct first costume down to exactly reach the damage we want
            result[0] = (result[0].Item1, result[0].Item2 + waveDmg);

            return result;
        }

        #endregion
    }
}
