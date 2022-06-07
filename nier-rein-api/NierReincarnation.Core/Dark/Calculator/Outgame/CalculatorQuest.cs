using System;
using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Dark.Calculator.Factory;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorQuest
    {
        private static readonly int kInvalidQuestMissionConditionGroupId = 0; // 0xC

        // CUSTOM: Get event quest chapters by type
        public static List<EventQuestChapterData> GetEventQuestChapters(params EventQuestType[] types)
        {
            var chapterTable = DatabaseDefine.Master.EntityMEventQuestChapterTable;
            var seqGroupTable = DatabaseDefine.Master.EntityMEventQuestSequenceGroupTable;

            var result = new List<EventQuestChapterData>();
            foreach (var chapter in chapterTable.All)
            {
                if (!types.Contains(chapter.EventQuestType))
                    continue;

                result.Add(new EventQuestChapterData
                {
                    EventQuestChapterId = chapter.EventQuestChapterId,
                    EventQuestType = chapter.EventQuestType,
                    EventQuestName = GetEventQuestChapterName(chapter.NameEventQuestTextId, chapter.EventQuestType),
                    EventQuestChapterDifficultyTypes = seqGroupTable.All.Where(x => x.EventQuestSequenceGroupId == chapter.EventQuestSequenceGroupId).Select(x => x.DifficultyType).ToList(),

                    StartDatetime = chapter.StartDatetime,
                    EndDatetime = chapter.EndDatetime
                });
            }

            return result;
        }

        // CUSTOM: Get main quest seasons
        public static List<MainQuestSeasonData> GetMainQuestSeasons()
        {
            var result = new List<MainQuestSeasonData>();

            var seasonTable = DatabaseDefine.Master.EntityMMainQuestSeasonTable;
            foreach (var season in seasonTable.All)
                result.Add(new MainQuestSeasonData
                {
                    MainQuestSeasonId = season.MainQuestSeasonId,
                    MainQuestSeasonName = GetMainQuestSeasonName(season.SortOrder)
                });

            return result;
        }

        // CUSTOM: Get main quest chapters
        public static List<MainQuestChapterData> GetMainQuestChapters(int seasonId)
        {
            var result = new List<MainQuestChapterData>();

            var chapterTable = DatabaseDefine.Master.EntityMMainQuestChapterTable;
            var routeTable = DatabaseDefine.Master.EntityMMainQuestRouteTable;
            var sequenceGroupTable = DatabaseDefine.Master.EntityMMainQuestSequenceGroupTable;

            var route = routeTable.All.FirstOrDefault(x => x.MainQuestSeasonId == seasonId);
            if (route == null)
                return result;

            var chapters = chapterTable.All.Where(x => x.MainQuestRouteId == route.MainQuestRouteId);
            foreach (var chapter in chapters)
            {
                var sequenceGroups = sequenceGroupTable.All.Where(x => x.MainQuestSequenceGroupId == chapter.MainQuestSequenceGroupId);

                result.Add(new MainQuestChapterData
                {
                    MainQuestChapterId = chapter.MainQuestChapterId,
                    MainQuestChapterName = GetMainQuestChapterName(GetMainQuestSeasonSortOrder(seasonId), route.SortOrder, chapter.SortOrder),
                    MainQuestChapterNumberName = GetMainQuestChapterNumberName(GetMainQuestSeasonSortOrder(seasonId), route.SortOrder, chapter.SortOrder),
                    MainQuestChapterDifficultyTypes = sequenceGroups.Select(x => x.DifficultyType).ToList()
                });
            }

            return result;
        }

        // CUSTOM: Get list of wave data by quest
        public static IList<DataDeck> GetWaveDataList(int questId, out long npcId)
        {
            npcId = 0;
            var result = new List<DataDeck>();

            var table = DatabaseDefine.Master.EntityMQuestSceneBattleTable;
            var table1 = DatabaseDefine.Master.EntityMBattleGroupTable;

            var sceneList = CreateQuestFieldSceneList(questId);
            foreach (var scene in sceneList)
            {
                var sceneBattle = table.FindByQuestSceneId(scene.QuestSceneId);
                if (sceneBattle == null)
                    continue;

                var battleGroups = table1.FindRangeByBattleGroupIdAndWaveNumber((sceneBattle.BattleGroupId, int.MinValue), (sceneBattle.BattleGroupId, int.MaxValue));
                foreach (var battleGroup in battleGroups.OrderBy(x => x.WaveNumber))
                {
                    var npcDeckInfo = GetEntityMBattleNpcDeck(battleGroup);
                    var deckEntity = CalculatorQuestSetupBattleWithNpcUserEntity.CreateEntityIUserDeck(npcDeckInfo.BattleNpcId, npcDeckInfo.DeckType, npcDeckInfo.BattleNpcDeckNumber, true);

                    npcId = npcDeckInfo.BattleNpcId;
                    result.Add(CalculatorNpcDeck.CreateNpcDataDeck(npcDeckInfo.BattleNpcId, deckEntity));
                }
            }

            return result;
        }

        public static List<CharacterQuestChapterData> GetCharacterQuestChapters()
        {
            return DatabaseDefine.Master.EntityMEventQuestChapterTable.All
                .Where(x => x.EventQuestType == EventQuestType.CHARACTER)
                .Where(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime))
                .OrderBy(x => x.DisplaySortOrder)
                .Select(x => new CharacterQuestChapterData
                {
                    EventQuestChapterId = x.EventQuestChapterId,
                    CharacterId = GetChapterCharacterId(x.EventQuestChapterId),
                    EventQuestName = GetQuestName(x.NameEventQuestTextId),

                    IsLock = GenerateEventQuestData(x.EventQuestChapterId, DifficultyType.NORMAL)[0].IsLock
                })
                .ToList();
        }

        public static List<CharacterQuestChapterData> GetEndQuestChapters()
        {
            return DatabaseDefine.Master.EntityMEventQuestChapterTable.All
                .Where(x => x.EventQuestType == EventQuestType.END_CONTENTS)
                .Where(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime))
                .OrderBy(x => x.DisplaySortOrder)
                .Select(x => new CharacterQuestChapterData
                {
                    EventQuestChapterId = x.EventQuestChapterId,
                    CharacterId = GetChapterCharacterId(x.EventQuestChapterId),
                    EventQuestName = GetQuestName(x.NameEventQuestTextId),

                    IsLock = !CalculatorWeapon.GetAfterEvolutionWeapons(CalculatorCharacter.GetEndWeaponId(GetChapterCharacterId(x.EventQuestChapterId))).Any(y => CalculatorWeapon.HasWeapon(CalculatorStateUser.GetUserId(), y))
                })
                .ToList();
        }

        public static int GetChapterCharacterId(int eventQuestChapterId)
        {
            var table = DatabaseDefine.Master.EntityMEventQuestChapterCharacterTable;
            return table.FindByEventQuestChapterId(eventQuestChapterId).CharacterId;
        }

        private static EntityMBattleNpcDeck GetEntityMBattleNpcDeck(EntityMBattleGroup entityMBattleGroup)
        {
            var table = DatabaseDefine.Master.EntityMBattleTable;
            var table1 = DatabaseDefine.Master.EntityMBattleNpcDeckTable;

            var battle = table.FindByBattleId(entityMBattleGroup.BattleId);
            return table1.FindByBattleNpcIdAndDeckTypeAndBattleNpcDeckNumber((battle.BattleNpcId, DeckType.QUEST, battle.BattleNpcDeckNumber));
        }

        public static List<EventQuestData> GenerateEventQuestData(int eventQuestChapterId, DifficultyType difficulty)
        {
            var chapterTable = DatabaseDefine.Master.EntityMEventQuestChapterTable;
            var eventQuestChapter = chapterTable.FindByEventQuestChapterId(eventQuestChapterId);

            var quests = GetEventQuestList(eventQuestChapterId, difficulty);
            var userId = CalculatorStateUser.GetUserId();

            var result = new List<EventQuestData>();
            foreach (var quest in quests)
            {
                var eventQuest = CreateEventQuestData(userId, quest, null, out _);

                // CUSTOM: Check term here, to determine further availability
                eventQuest.IsAvailable &= CalculatorDateTime.IsWithinThePeriod(eventQuestChapter.StartDatetime, eventQuestChapter.EndDatetime);

                result.Add(eventQuest);
            }

            return result;
        }

        // TODO: Use after identifying the chapters with another method
        public static ChapterQuestData GenerateMainQuestData(int chapterId, DifficultyType difficulty)
        {
            var chapterTable = DatabaseDefine.Master.EntityMMainQuestChapterTable;
            var sequenceGroupTable = DatabaseDefine.Master.EntityMMainQuestSequenceGroupTable;
            var sequenceTable = DatabaseDefine.Master.EntityMMainQuestSequenceTable;
            var questTable = DatabaseDefine.Master.EntityMQuestTable;
            var routeTable = DatabaseDefine.Master.EntityMMainQuestRouteTable;
            var sceneTable = DatabaseDefine.Master.EntityMQuestSceneTable;

            var chapter = chapterTable.FindByMainQuestChapterId(chapterId);
            var sequenceGroup = sequenceGroupTable.FindByMainQuestSequenceGroupIdAndDifficultyType((chapter.MainQuestSequenceGroupId, difficulty));
            var mainSequences = sequenceTable.All.Where(x => x.MainQuestSequenceId == sequenceGroup.MainQuestSequenceId).OrderBy(x => x.SortOrder);

            var cellData = new List<QuestCellData>();
            foreach (var sequence in mainSequences)
            {
                var quest = questTable.FindByQuestId(sequence.QuestId);
                var scenes = sceneTable.All.Where(x => x.QuestId == quest.QuestId).ToList();

                cellData.Add(GenerateMainQuestData(chapter, sequenceGroup, sequence, quest, scenes));
            }

            var mainRoute = routeTable.FindByMainQuestRouteId(chapter.MainQuestRouteId);
            var mainSeasonSortOrder = GetMainQuestSeasonSortOrder(mainRoute.MainQuestSeasonId);

            return new ChapterQuestData
            {
                ChapterNumberName = GetMainQuestChapterNumberName(chapter),
                ChapterTitle = GetMainQuestChapterName(mainSeasonSortOrder, mainRoute.SortOrder, chapter.SortOrder),
                ChapterSortOrder = chapter.SortOrder,
                QuestDataList = cellData
            };
        }

        public static QuestCellData GenerateMainQuestData(int questSceneId)
        {
            var scene = DatabaseDefine.Master.EntityMQuestSceneTable.FindByQuestSceneId(questSceneId);
            var quest = DatabaseDefine.Master.EntityMQuestTable.FindByQuestId(scene.QuestId);
            var sequence = DatabaseDefine.Master.EntityMMainQuestSequenceTable.All.FirstOrDefault(x => x.QuestId == quest.QuestId);
            if (sequence == null)
                return null;

            var sequenceGroup = DatabaseDefine.Master.EntityMMainQuestSequenceGroupTable.All.FirstOrDefault(x => x.MainQuestSequenceId == sequence.MainQuestSequenceId);
            if (sequenceGroup == null)
                return null;

            var chapter = DatabaseDefine.Master.EntityMMainQuestChapterTable.All.FirstOrDefault(x => x.MainQuestSequenceGroupId == sequenceGroup.MainQuestSequenceGroupId);
            if (chapter == null)
                return null;

            var scenes = DatabaseDefine.Master.EntityMQuestSceneTable.All.Where(x => x.QuestId == quest.QuestId).ToList();
            return GenerateMainQuestData(chapter, sequenceGroup, sequence, quest, scenes);
        }

        private static QuestCellData GenerateMainQuestData(EntityMMainQuestChapter chapter, EntityMMainQuestSequenceGroup sequenceGroup, EntityMMainQuestSequence sequence, EntityMQuest quest, List<EntityMQuestScene> scenes)
        {
            return new QuestCellData
            {
                Quest = new MainQuest(chapter, sequenceGroup, sequence, quest),
                QuestName = GetQuestName(quest.NameQuestTextId),
                Missions = GetMissionData(quest.QuestId, quest.QuestMissionGroupId, CalculatorStateUser.GetUserId()),
                IsStoryQuest = true,
                IsLock = !IsUnlockedQuest(quest.QuestReleaseConditionListId, CalculatorStateUser.GetUserId()),
                QuestOrder = sequence.SortOrder,

                Scenes = scenes,
                IsClear = IsClearQuest(quest.QuestId, CalculatorStateUser.GetUserId())
                //UnlockQuestText = GetQuestUnlockText(quest.QuestReleaseConditionListId),
                //QuestLevelText = 
            };
        }

        private static List<IQuest> GetEventQuestList(int eventQuestChapterId, DifficultyType difficultyType)
        {
            var chapterTable = DatabaseDefine.Master.EntityMEventQuestChapterTable;
            var seqGroupTable = DatabaseDefine.Master.EntityMEventQuestSequenceGroupTable;
            var seqTable = DatabaseDefine.Master.EntityMEventQuestSequenceTable;
            var questTable = DatabaseDefine.Master.EntityMQuestTable;

            var eventQuestChapter = chapterTable.FindByEventQuestChapterId(eventQuestChapterId);
            var questGroup = seqGroupTable.FindByEventQuestSequenceGroupIdAndDifficultyType((eventQuestChapter.EventQuestSequenceGroupId, difficultyType));
            var quests = seqTable.All.Where(x => x.EventQuestSequenceId == questGroup.EventQuestSequenceId).OrderBy(x => x.SortOrder);

            var result = new List<IQuest>();
            foreach (var quest in quests)
                result.Add(new EventQuest(eventQuestChapter, questGroup, quest, questTable.FindByQuestId(quest.QuestId)));

            return result;
        }

        // CUSTOM: Create event quest data from quest id
        public static EventQuestData CreateEventQuestData(int questId)
        {
            var questSequence = DatabaseDefine.Master.EntityMEventQuestSequenceTable.All.FirstOrDefault(x => x.QuestId == questId);
            if (questSequence == null)
                return null;

            var questGroup = DatabaseDefine.Master.EntityMEventQuestSequenceGroupTable.All.FirstOrDefault(x => x.EventQuestSequenceId == questSequence.EventQuestSequenceId);
            if (questGroup == null)
                return null;

            var eventQuestChapter = DatabaseDefine.Master.EntityMEventQuestChapterTable.All.FirstOrDefault(x => x.EventQuestSequenceGroupId == questGroup.EventQuestSequenceGroupId);
            if (eventQuestChapter == null)
                return null;

            var quest = DatabaseDefine.Master.EntityMQuestTable.FindByQuestId(questId);
            if (quest == null)
                return null;

            var userId = CalculatorStateUser.GetUserId();
            var eventQuest = new EventQuest(eventQuestChapter, questGroup, questSequence, quest);

            return CreateEventQuestData(userId, eventQuest, null, out _);
        }

        private static EventQuestData CreateEventQuestData(long userId, IQuest eventQuest, Action<EventQuestData> onQuestButtonTap, out bool isLock)
        {
            var questId = eventQuest.QuestId;
            var masterQuest = eventQuest.EntityQuest;
            var dailyCount = masterQuest.DailyClearableCount;

            var isUnlocked = IsUnlockedQuest(masterQuest.QuestReleaseConditionListId, userId);
            var canPlay = CanPlayQuestCheckCount(userId, questId, dailyCount);

            var isClear = IsClearQuest(questId, userId);
            var isAvailable = !isClear || !masterQuest.IsNotShowAfterClear;
            isAvailable &= IsWithinQuestTerm(questId);

            isLock = !isAvailable || !isUnlocked || !canPlay;

            var sceneId = CreateQuestFieldSceneList(eventQuest.QuestId).Select(x => x.QuestSceneId).FirstOrDefault();

            return new EventQuestData
            {
                Quest = eventQuest,
                IsClearQuest = isClear,
                AttributeType = GetFirstQuestDisplayAttributeType(masterQuest.QuestDisplayAttributeGroupId),
                QuestName = GetQuestName(masterQuest.NameQuestTextId),
                QuestFirstReward = GenerateFirstReward(masterQuest.QuestFirstClearRewardGroupId),
                IsLock = isLock,
                Stamina = masterQuest.Stamina,
                RecommendPower = masterQuest.RecommendedDeckPower,
                IsStoryQuest = masterQuest.StoryQuestTextId != 0,
                MissionData = GetMissionData(questId, masterQuest.QuestMissionGroupId, userId),
                Campaigns = CalculatorCampaign.CreateDataQuestCampaign(eventQuest),

                IsAvailable = isAvailable,
                SceneId = sceneId,
                ClearCount = GetClearCount(userId, questId)
            };
        }

        public static bool IsClearQuest(int questId, long userId)
        {
            var table = DatabaseDefine.User.EntityIUserQuestTable;
            return table.FindByUserIdAndQuestId((userId, questId))?.QuestStateType == 2;
        }

        // CUSTOM: Check quest lock by quest ID
        public static bool IsUnlockedQuest(int questId)
        {
            var masterQuest = DatabaseDefine.Master.EntityMQuestTable.FindByQuestId(questId);
            if (masterQuest == null)
                return false;

            return IsUnlockedQuest(masterQuest.QuestReleaseConditionListId, CalculatorStateUser.GetUserId());
        }

        public static bool IsUnlockedQuest(int questReleaseConditionListId, long userId)
        {
            var table = DatabaseDefine.Master.EntityMQuestReleaseConditionListTable;
            var table2 = DatabaseDefine.Master.EntityMQuestReleaseConditionGroupTable;

            var condList = table.FindByQuestReleaseConditionListId(questReleaseConditionListId);
            var condGroups = table2.All.Where(x => x.QuestReleaseConditionGroupId == condList.QuestReleaseConditionGroupId).OrderBy(x => x.SortOrder);

            if (condList == null)
                return true;

            bool result;
            switch (condList.ConditionOperationType)
            {
                case ConditionOperationType.OR:
                    result = false;
                    foreach (var cond in condGroups)
                        result |= IsCheckReleaseCondition(cond.QuestReleaseConditionId, cond.QuestReleaseConditionType, userId);

                    return result;

                case ConditionOperationType.AND:
                    result = true;
                    foreach (var cond in condGroups)
                        result &= IsCheckReleaseCondition(cond.QuestReleaseConditionId, cond.QuestReleaseConditionType, userId);

                    return result;
            }

            return false;
        }

        private static bool IsCheckReleaseCondition(int questReleaseConditionId, QuestReleaseConditionType questReleaseConditionType, long userId)
        {
            switch (questReleaseConditionType)
            {
                case QuestReleaseConditionType.USER_LEVEL:
                    return IsCheckUserLevel(questReleaseConditionId, userId);

                case QuestReleaseConditionType.CHARACTER_LEVEL:
                    return IsCheckCharacterLevel(questReleaseConditionId, userId);

                case QuestReleaseConditionType.DECK_POWER:
                    return IsCheckDeckPower(questReleaseConditionId, userId);

                case QuestReleaseConditionType.QUEST_CLEAR:
                    return IsCheckQuestClear(questReleaseConditionId, userId);

                case QuestReleaseConditionType.WEAPON_ACQUISITION:
                    return IsCheckAcquisition(questReleaseConditionId, userId);

                case QuestReleaseConditionType.BIG_HUNT_SCORE:
                    return IsCheckBigHuntScore(questReleaseConditionId, userId);

                default:
                    return true;
            }
        }

        private static bool IsCheckUserLevel(int questReleaseConditionId, long userId)
        {
            var table = DatabaseDefine.Master.EntityMQuestReleaseConditionUserLevelTable;
            var condUserLvl = table.FindByQuestReleaseConditionId(questReleaseConditionId);

            var table1 = DatabaseDefine.User.EntityIUserStatusTable;
            return table1.FindByUserId(userId).Level >= condUserLvl.UserLevel;
        }

        private static bool IsCheckCharacterLevel(int questReleaseConditionId, long userId)
        {
            var table = DatabaseDefine.Master.EntityMQuestReleaseConditionCharacterLevelTable;
            var condCharLvl = table.FindByQuestReleaseConditionId(questReleaseConditionId);

            var table1 = DatabaseDefine.User.EntityIUserCharacterTable;
            if (!table1.TryFindByUserIdAndCharacterId((userId, condCharLvl.CharacterId), out var userCharLvl))
                return false;

            return userCharLvl.Level >= condCharLvl.CharacterLevel;
        }

        private static bool IsCheckDeckPower(int questReleaseConditionId, long userId)
        {
            var table = DatabaseDefine.Master.EntityMQuestReleaseConditionDeckPowerTable;
            var userDeckPwr = table.FindByQuestReleaseConditionId(questReleaseConditionId);

            var table1 = DatabaseDefine.User.EntityIUserDeckTypeNoteTable;
            return table1.All.Where(x => x.UserId == userId).Any(x => userDeckPwr.MaxDeckPower <= x.MaxDeckPower);
        }

        private static bool IsCheckQuestClear(int questReleaseConditionId, long userId)
        {
            var table = DatabaseDefine.Master.EntityMQuestReleaseConditionQuestClearTable;
            var masterClear = table.FindByQuestReleaseConditionId(questReleaseConditionId);

            return IsClearQuest(masterClear.QuestId, userId);
        }

        private static bool IsCheckAcquisition(int questReleaseConditionId, long userId)
        {
            var table = DatabaseDefine.Master.EntityMQuestReleaseConditionWeaponAcquisitionTable;
            var weaponAq = table.FindByQuestReleaseConditionId(questReleaseConditionId);

            var table1 = DatabaseDefine.User.EntityIUserWeaponNoteTable;
            return table1.TryFindByUserIdAndWeaponId((userId, weaponAq.WeaponId), out _);
        }

        private static bool IsCheckBigHuntScore(int questReleaseConditionId, long userId)
        {
            var table = DatabaseDefine.Master.EntityMQuestReleaseConditionBigHuntScoreTable;
            var bigBoss = table.FindByQuestReleaseConditionId(questReleaseConditionId);

            var highScore = CalculatorBigHuntQuest.GetHighScoreByBigHuntBossId(userId, bigBoss.BigHuntBossId);
            return bigBoss.NecessaryScore <= highScore;
        }

        public static bool CanPlayQuestCheckCount(long userId, int questId, int dailyClearableCount)
        {
            var table = DatabaseDefine.User.EntityIUserQuestTable;
            var userQuest = table.FindByUserIdAndQuestId((userId, questId));

            if (dailyClearableCount == 0 || userQuest == null)
                return true;

            if (userQuest.LastClearDatetime == 0)
                throw new ArgumentNullException("Quest has invalid clear time.");

            var isAfterToday = CalculatorDateTime.IsAfterTodaySpanningTime(CalculatorDateTime.FromUnixTime(userQuest.LastClearDatetime));
            return userQuest.DailyClearCount < dailyClearableCount | !isAfterToday;
        }

        private static int GetClearCount(long userId, int questId)
        {
            var table = DatabaseDefine.User.EntityIUserQuestTable;
            var userQuest = table.FindByUserIdAndQuestId((userId, questId));
            if (userQuest == null)
                return 0;

            return userQuest.ClearCount;
        }

        public static QuestDisplayAttributeType GetFirstQuestDisplayAttributeType(int questDisplayAttributeGroupId)
        {
            var attributeData = GenerateQuestDisplayAttributeData(questDisplayAttributeGroupId).FirstOrDefault();
            if (attributeData == null)
                return QuestDisplayAttributeType.VARIOUS;

            return attributeData.QuestDisplayAttributeType;
        }

        private static QuestAttributeData[] GenerateQuestDisplayAttributeData(int questDisplayAttributeGroupId)
        {
            var table = DatabaseDefine.Master.EntityMQuestDisplayAttributeGroupTable;
            var sortedData = table.All.Where(x => x.QuestDisplayAttributeGroupId == questDisplayAttributeGroupId)
                .OrderBy(x => x.SortOrder)
                .Select(x => new QuestAttributeData
                {
                    QuestDisplayAttributeType = x.QuestDisplayAttributeType,
                    QuestDisplayAttributeIconSizeType = x.QuestDisplayAttributeIconSizeType
                });

            return sortedData.ToArray();
        }

        private static string GetQuestName(int nameTextId)
        {
            return string.Format(UserInterfaceTextKey.Quest.kQuestNameTextKey, nameTextId).Localize();
        }

        public static string QuestName(int questId)
        {
            var masterQuest = DatabaseDefine.Master.EntityMQuestTable.FindByQuestId(questId);
            return GetQuestName(masterQuest.NameQuestTextId);
        }

        private static DataPossessionItem GenerateFirstReward(int questFirstClearRewardGroupId)
        {
            var table = DatabaseDefine.Master.EntityMQuestFirstClearRewardGroupTable;
            var rewardGroup = table.All.Where(x => x.QuestFirstClearRewardType == QuestFirstClearRewardType.NORMAL)
                .Where(x => x.QuestFirstClearRewardGroupId == questFirstClearRewardGroupId)
                .OrderBy(x => x.SortOrder)
                .FirstOrDefault();

            if (rewardGroup == null)
                return null;

            return new DataPossessionItem
            {
                PossessionId = rewardGroup.PossessionId,
                PossessionType = rewardGroup.PossessionType,
                Count = rewardGroup.Count
            };
        }

        private static QuestMissionData[] GetMissionData(int questId, int questMissionGroupId, long userId)
        {
            var table = DatabaseDefine.Master.EntityMQuestMissionGroupTable;
            var missionGroups = table.All.Where(x => x.QuestMissionGroupId == questMissionGroupId);

            var result = new List<QuestMissionData>();
            foreach (var missionGroup in missionGroups)
                result.Add(GenerateQuestMissionData(questId, missionGroup.QuestMissionId, userId));

            return result.ToArray();
        }

        public static QuestMissionData GenerateQuestMissionData(int questId, int questMissionId, long userId)
        {
            var table = DatabaseDefine.Master.EntityMQuestMissionTable;
            var masterMission = table.FindByQuestMissionId(questMissionId);

            var condValues = GenerateQuestMissionConditionValues(masterMission.QuestMissionConditionValueGroupId);
            return new QuestMissionData
            {
                MissionId = masterMission.QuestMissionId,
                MissionTitle = GenerateMissionText(masterMission.QuestMissionConditionType, masterMission.ConditionValue, condValues),
                IsClear = IsMissionClear(questId, masterMission.QuestMissionId, userId),
                QuestMissionConditionType = masterMission.QuestMissionConditionType
            };
        }

        public static List<int> GenerateQuestMissionConditionValues(int questMissionConditionValueGroupId)
        {
            if (questMissionConditionValueGroupId == kInvalidQuestMissionConditionGroupId)
                return null;

            var table = DatabaseDefine.Master.EntityMQuestMissionConditionValueGroupTable;
            var range = table.FindRangeByQuestMissionConditionValueGroupIdAndSortOrder((questMissionConditionValueGroupId, int.MinValue), (questMissionConditionValueGroupId, int.MaxValue));

            var result = new List<int>();
            foreach (var item in range)
                result.Add(item.ConditionValue);

            return result;
        }

        public static string GenerateMissionText(QuestMissionConditionType questMissionConditionType, int value, List<int> questMissionConditionValueList)
        {
            // TODO: Implement mission text
            return string.Empty;
        }

        public static bool IsMissionClear(int questId, int questMissionId, long userId)
        {
            var table = DatabaseDefine.User.EntityIUserQuestMissionTable;
            if (!table.TryFindByUserIdAndQuestIdAndQuestMissionId((userId, questId, questMissionId), out var result))
                return false;

            return result.IsClear;
        }

        public static string GetEventQuestChapterName(int nameTextId, EventQuestType eventQuestType = EventQuestType.UNKNOWN)
        {
            switch (eventQuestType)
            {
                case EventQuestType.DAY_OF_THE_WEEK:
                    return UserInterfaceTextKey.Quest.kEventQuestDayOfTheWeek.Localize();

                case EventQuestType.GUERRILLA:
                    return UserInterfaceTextKey.Quest.kEventQuestGuerrilla.Localize();

                case EventQuestType.CHARACTER:
                    return UserInterfaceTextKey.Quest.kEventQuestCharacter.Localize();

                case EventQuestType.END_CONTENTS:
                    return UserInterfaceTextKey.Quest.kEventQuestEndContents.Localize();

                default:
                    if (nameTextId == 0)
                        return null;

                    return string.Format(UserInterfaceTextKey.Quest.kEventChapterTitle, nameTextId).Localize();
            }
        }

        public static List<EntityMQuestScene> CreateQuestFieldSceneList(int questId)
        {
            var table = DatabaseDefine.Master.EntityMQuestSceneTable;
            return table.All.Where(x => x.QuestId == questId && x.QuestSceneType == QuestSceneType.FIELD).ToList();
        }

        public static bool IsWithinQuestTerm(int questId, long graceTimeMilliSeconds = 0)
        {
            var table = DatabaseDefine.Master.EntityMQuestScheduleCorrespondenceTable;
            var correspondence = table.All.FirstOrDefault(x => x.QuestId == questId);
            if (correspondence == null)
                return true;

            var table1 = DatabaseDefine.Master.EntityMQuestScheduleTable;
            var schedule = table1.FindByQuestScheduleId(correspondence.QuestScheduleId);
            if (schedule == null)
                return false;

            return CalculatorDateTime.IsWithinThePeriod(schedule.StartDatetime, schedule.EndDatetime);
        }

        public static bool IsValidEventQuestTerm(int eventQuestId)
        {
            var table = DatabaseDefine.Master.EntityMQuestScheduleCorrespondenceTable;
            var schedules = table.All.Where(x => x.QuestId == eventQuestId).ToArray();
            if (!schedules.Any())
                return true;

            foreach (var correspondence in schedules)
            {
                var table1 = DatabaseDefine.Master.EntityMQuestScheduleTable;
                var schedule = table1.FindByQuestScheduleId(correspondence.QuestScheduleId);
                if (schedule == null)
                    continue;

                var isInTerm = CalculatorDateTime.IsWithinThePeriod(schedule.StartDatetime, schedule.EndDatetime);
                if (!isInTerm)
                    continue;

                var validCron = IsValidEventQuestCronTime(schedule.QuestScheduleCronExpression);
                if (validCron)
                    return true;
            }

            return false;
        }

        private static bool IsValidEventQuestCronTime(string questScheduleCronExpression)
        {
            // TODO: Implement Crontab validation?
            // HINT: Assume valid crontab
            return true;
        }

        public static string GetMainQuestChapterNumberName(EntityMMainQuestChapter entityMMainQuestChapter)
        {
            var table = DatabaseDefine.Master.EntityMMainQuestRouteTable;
            var masterRoute = table.FindByMainQuestRouteId(entityMMainQuestChapter.MainQuestRouteId);

            var table1 = DatabaseDefine.Master.EntityMMainQuestSeasonTable;
            var masterSeason = table1.FindByMainQuestSeasonId(masterRoute.MainQuestSeasonId);

            return GetMainQuestChapterNumberName(masterSeason.SortOrder, masterRoute.SortOrder, entityMMainQuestChapter.SortOrder);
        }

        public static string GetListMainQuestChapterName(EntityMMainQuestChapter entityMMainQuestChapter)
        {
            var chapterText = GetMainQuestChapterText(entityMMainQuestChapter.MainQuestRouteId, entityMMainQuestChapter.SortOrder);
            return chapterText.Item1 + chapterText.Item2;
        }

        public static (string, string) GetMainQuestChapterText(int mainQuestRouteId, int mainQuestSortOrder)
        {
            var table = DatabaseDefine.Master.EntityMMainQuestRouteTable;
            var masterRoute = table.FindByMainQuestRouteId(mainQuestRouteId);

            var seasonSortOrder = GetMainQuestSeasonSortOrder(masterRoute.MainQuestSeasonId);
            var chapterNumber = GetMainQuestChapterNumberName(seasonSortOrder, masterRoute.SortOrder, mainQuestSortOrder);
            var chapterName = GetMainQuestChapterName(seasonSortOrder, masterRoute.SortOrder, mainQuestSortOrder);

            return (chapterNumber, chapterName);
        }

        public static int GetMainQuestSeasonSortOrder(int seasonId)
        {
            return GetEntityMMainQuestSeason(seasonId).SortOrder;
        }

        private static string GetMainQuestChapterNumberName(int seasonSortOrder, int routeSortOrder, int chapterSortOrder)
        {
            return string.Format(UserInterfaceTextKey.Quest.kMainChapterNumber, seasonSortOrder, routeSortOrder, chapterSortOrder).Localize();
        }

        private static string GetMainQuestChapterName(int seasonSortOrder, int routeSortOrder, int chapterSortOrder)
        {
            return string.Format(UserInterfaceTextKey.Quest.kMainChapterTitle, seasonSortOrder, routeSortOrder, chapterSortOrder).Localize();
        }

        private static EntityMMainQuestSeason GetEntityMMainQuestSeason(int mainQuestSeasonId)
        {
            var table = DatabaseDefine.Master.EntityMMainQuestSeasonTable;
            return table.FindByMainQuestSeasonId(mainQuestSeasonId);
        }

        public static string GetQuestUnlockText(int releaseConditionQuestListId)
        {
            var condText = GetQuestUnlockConditionText(releaseConditionQuestListId);
            return condText + UserInterfaceTextKey.Unlock.kUnLockBy.Localize();
        }

        private static string GetQuestUnlockConditionText(int releaseConditionQuestListId)
        {
            // TODO: Implement unlock condition localization
            return string.Empty;
        }

        #region Main Quest relevancy

        public static bool IsUnlockMainQuestChapter(long userId, int mainChapterId)
        {
            var masterChapter = DatabaseDefine.Master.EntityMMainQuestChapterTable.FindByMainQuestChapterId(mainChapterId);
            var questSequenceGroup = DatabaseDefine.Master.EntityMMainQuestSequenceGroupTable.FindByMainQuestSequenceGroupIdAndDifficultyType((masterChapter.MainQuestSequenceGroupId, DifficultyType.NORMAL));
            var sequences = DatabaseDefine.Master.EntityMMainQuestSequenceTable.All.Where(x => x.MainQuestSequenceId == questSequenceGroup.MainQuestSequenceId);
            var quests = sequences.Select(x => DatabaseDefine.Master.EntityMQuestTable.FindByQuestId(x.QuestId));

            return quests.Any(x => IsUnlockedQuest(x.QuestReleaseConditionListId, userId));
        }

        //public static DifficultyType GetCurrentReleaseMaxDifficulty(int mainQuestChapterId) { }

        //public static int GetMainQuestSeasonIdByChapterId(int chapterId) { }

        public static string GetMainQuestSeasonName(int seasonSortOrder)
        {
            if (seasonSortOrder == 0)
                return null;

            return string.Format(UserInterfaceTextKey.Quest.kMainSeasonTitle, seasonSortOrder).Localize();
        }

        #endregion

        #region Deck restriction

        public static bool IsDeckRestriction(int questId)
        {
            return QuestDeckRestrictionGroupId(questId) != 0;
        }

        private static int QuestDeckRestrictionGroupId(int questId)
        {
            var questTable = DatabaseDefine.Master.EntityMQuestTable;
            var masterQuest = questTable.FindByQuestId(questId);

            return masterQuest.QuestDeckRestrictionGroupId;
        }

        //public static DataDeckRestriction[] CreateDeckRestrictionList(int questId)
        //{

        //}

        #endregion
    }
}
