﻿using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Component.Story.Ghost;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorBigHuntQuest
    {
        public static long GetHighScoreByBigHuntBossId(long userId, int bigHuntBossId)
        {
            var table = DatabaseDefine.User.EntityIUserBigHuntMaxScoreTable;
            return table.FindByUserIdAndBigHuntBossId((userId, bigHuntBossId))?.MaxScore ?? 0;
        }

        // CUSTOM: Generate boss quests
        public static List<BigHuntBossQuestData> GenerateBigHuntBossQuestDataList(long userId)
        {
            var result = new List<BigHuntBossQuestData>();

            var bossQuestTable = DatabaseDefine.Master.EntityMBigHuntBossQuestTable;
            foreach (var bossQuest in bossQuestTable.All)
                result.Add(GenerateBigHuntBossQuestData(userId, bossQuest.BigHuntBossQuestId));

            return result;
        }

        // CUSTOM: Generate boss bigHuntQuest data
        private static BigHuntBossQuestData GenerateBigHuntBossQuestData(long userId, int bigHuntBossQuestId)
        {
            var bossQuestTable = DatabaseDefine.Master.EntityMBigHuntBossQuestTable;
            var bossQuest = bossQuestTable.FindByBigHuntBossQuestId(bigHuntBossQuestId);

            var bossTable = DatabaseDefine.Master.EntityMBigHuntBossTable;
            var boss = bossTable.FindByBigHuntBossId(bossQuest.BigHuntBossId);

            return new BigHuntBossQuestData
            {
                BigHuntBossQuestId = bigHuntBossQuestId,
                BigHuntBossGradeGroupId = boss.BigHuntBossGradeGroupId,
                BossQuestName = GetBigHuntBossName(boss.NameBigHuntBossTextId),
                HighScore = GetHighScoreByBigHuntBossId(userId, boss.BigHuntBossId),
                IsClear = IsClearBigHuntBoss(userId, bigHuntBossQuestId),
                RemainChallengeCount = GetRemainDailyChallengeCount(bigHuntBossQuestId),
                AttributeType = boss.AttributeType,
                BigHuntQuestDataList = GenerateBigHuntQuestDataList(bigHuntBossQuestId)
            };
        }

        // CUSTOM: Generate list of big hunt bigHuntQuest data
        private static List<BigHuntQuestData> GenerateBigHuntQuestDataList(int bigHuntBossQuestId)
        {
            var questList = CreateBigHuntQuestList(bigHuntBossQuestId);

            var result = new List<BigHuntQuestData>();
            foreach (var quest in questList)
                result.Add(GenerateBigHuntQuestData(bigHuntBossQuestId, quest.BigHuntQuestId));

            return result;
        }

        // CUSTOM: Generate big hunt quest data
        public static BigHuntQuestData GenerateBigHuntQuestData(int bigHuntBossQuestId, int bigHuntQuestId)
        {
            var quest = CreateBigHuntQuest(bigHuntQuestId);

            var coefficientId = (quest.Quest as BigHuntQuest).EntityQuestSequence.BigHuntQuestScoreCoefficientId;
            var coefficientPermil = DatabaseDefine.Master.EntityMBigHuntQuestScoreCoefficientTable.FindByBigHuntQuestScoreCoefficientId(coefficientId);

            return new BigHuntQuestData
            {
                BigHuntBossQuestId = bigHuntBossQuestId,
                Quest = quest.Quest,
                IsClearQuest = CalculatorQuest.IsClearQuest(quest.Quest.QuestId, CalculatorStateUser.GetUserId()),
                IsLock = !CalculatorQuest.IsUnlockedQuest(quest.Quest.EntityQuest.QuestReleaseConditionListId, CalculatorStateUser.GetUserId()),
                RecommendPower = quest.Quest.EntityQuest.RecommendedDeckPower,
                QuestName = CalculatorQuest.QuestName(quest.Quest.QuestId),

                DifficultyBonusPermilValue = coefficientPermil.ScoreDifficultBonusPermil,
                AttributeType = QuestDisplayAttributeType.ALL,
                SortOrder = quest.SortOrder
            };
        }

        // CUSTOM: Create big hunt quest data list from big hunt boss quest ID
        private static List<BigHuntStoryQuestData> CreateBigHuntQuestList(int bigHuntBossQuestId)
        {
            var bossQuestTable = DatabaseDefine.Master.EntityMBigHuntBossQuestTable;
            var bigHuntGroupTable = DatabaseDefine.Master.EntityMBigHuntQuestGroupTable;
            var bigHuntQuestTable = DatabaseDefine.Master.EntityMBigHuntQuestTable;
            var questTable = DatabaseDefine.Master.EntityMQuestTable;

            var bossQuest = bossQuestTable.FindByBigHuntBossQuestId(bigHuntBossQuestId);
            var questGroups = bigHuntGroupTable.All.Where(x => x.BigHuntQuestGroupId == bossQuest.BigHuntQuestGroupId);

            var result = new List<BigHuntStoryQuestData>();
            foreach (var questGroup in questGroups)
            {
                var bigHuntQuest = bigHuntQuestTable.FindByBigHuntQuestId(questGroup.BigHuntQuestId);
                var quest = questTable.FindByQuestId(bigHuntQuest.QuestId);

                var chapter = new EntityMBigHuntStoryQuestChapter();
                var sequenceGroup = new EntityMBigHuntStoryQuestSequenceGroup();
                var sequence = new EntityMBigHuntStoryQuestSequence();

                chapter.Setup(bossQuest.BigHuntBossQuestId, bossQuest.BigHuntQuestGroupId);
                sequenceGroup.Setup(bossQuest.BigHuntQuestGroupId, questGroup.SortOrder, bigHuntQuest.BigHuntQuestId);
                sequence.Setup(bigHuntQuest.BigHuntQuestId, bigHuntQuest.QuestId, bigHuntQuest.BigHuntQuestScoreCoefficientId);

                result.Add(CreateBigHuntQuest(bigHuntQuest, chapter, sequenceGroup, sequence, quest, questGroup.SortOrder));
            }

            return result;
        }

        // CUSTOM: Create big hunt quest data from big hunt quest ID
        private static BigHuntStoryQuestData CreateBigHuntQuest(int bigHuntQuestId)
        {
            var bossQuestTable = DatabaseDefine.Master.EntityMBigHuntBossQuestTable;
            var bigHuntGroupTable = DatabaseDefine.Master.EntityMBigHuntQuestGroupTable;
            var bigHuntQuestTable = DatabaseDefine.Master.EntityMBigHuntQuestTable;
            var questTable = DatabaseDefine.Master.EntityMQuestTable;

            var bigHuntQuest = bigHuntQuestTable.All.FirstOrDefault(x => x.BigHuntQuestId == bigHuntQuestId);
            var quest = questTable.FindByQuestId(bigHuntQuest.QuestId);
            var questGroup = bigHuntGroupTable.All.FirstOrDefault(x => x.BigHuntQuestId == bigHuntQuestId);
            var bossQuest = bossQuestTable.All.FirstOrDefault(x => x.BigHuntQuestGroupId == questGroup.BigHuntQuestGroupId);

            var chapter = new EntityMBigHuntStoryQuestChapter();
            var sequenceGroup = new EntityMBigHuntStoryQuestSequenceGroup();
            var sequence = new EntityMBigHuntStoryQuestSequence();

            chapter.Setup(bossQuest.BigHuntBossQuestId, bossQuest.BigHuntQuestGroupId);
            sequenceGroup.Setup(bossQuest.BigHuntQuestGroupId, questGroup.SortOrder, bigHuntQuest.BigHuntQuestId);
            sequence.Setup(bigHuntQuest.BigHuntQuestId, bigHuntQuest.QuestId, bigHuntQuest.BigHuntQuestScoreCoefficientId);

            return CreateBigHuntQuest(bigHuntQuest, chapter, sequenceGroup, sequence, quest, questGroup.SortOrder);
        }

        // CUSTOM: Creates big hunt quest data instance
        private static BigHuntStoryQuestData CreateBigHuntQuest(EntityMBigHuntQuest bigHuntQuest, EntityMBigHuntStoryQuestChapter chapter, EntityMBigHuntStoryQuestSequenceGroup sequenceGroup, EntityMBigHuntStoryQuestSequence sequence, EntityMQuest quest, int sortOrder)
        {
            return new BigHuntStoryQuestData
            {
                BigHuntQuestId = bigHuntQuest.BigHuntQuestId,
                Quest = new BigHuntQuest(chapter, sequenceGroup, sequence, quest),
                SortOrder = sortOrder
            };
        }

        public static bool IsClearBigHuntBoss(long userId, int bigHuntBossQuestId)
        {
            var bossId = GetCurrentBossIdByBossQuestId(bigHuntBossQuestId);

            var maxScoreTable = DatabaseDefine.User.EntityIUserBigHuntMaxScoreTable;
            return maxScoreTable.TryFindByUserIdAndBigHuntBossId((userId, bossId), out _);
        }

        public static int GetCurrentBossIdByBossQuestId(int bossQuestId)
        {
            var bossQuestTable = DatabaseDefine.Master.EntityMBigHuntBossQuestTable;
            var bossQuest = bossQuestTable.FindByBigHuntBossQuestId(bossQuestId);

            return bossQuest.BigHuntBossId;
        }

        public static int GetRemainDailyChallengeCount(int bigHuntBossQuestId)
        {
            if (!TryGetEntityBigHuntQuest(bigHuntBossQuestId, out var bossQuest))
                return 0;

            return bossQuest.DailyChallengeCount - GetCurrentDailyChallengeCount(bigHuntBossQuestId);
        }

        private static bool TryGetEntityBigHuntQuest(int bigHuntBossQuestId, out EntityMBigHuntBossQuest entityBossQuest)
        {
            var table = DatabaseDefine.Master.EntityMBigHuntBossQuestTable;
            entityBossQuest = table.All.FirstOrDefault(x => x.BigHuntBossQuestId == bigHuntBossQuestId);

            return entityBossQuest != null;
        }

        private static int GetCurrentDailyChallengeCount(int bigHuntBossQuestId)
        {
            var table = DatabaseDefine.User.EntityIUserBigHuntStatusTable;
            var bigHuntStatus = table.FindByUserIdAndBigHuntBossQuestId((CalculatorStateUser.GetUserId(), bigHuntBossQuestId));
            if (bigHuntStatus == null)
                return 0;

            return CalculatorDateTime.IsAfterTodaySpanningTime(bigHuntStatus.LatestChallengeDatetime) ? bigHuntStatus.DailyChallengeCount : 0;
        }

        public static string GetBigHuntBossNameByBigHuntBossQuestId(int bigHuntBossQuestId)
        {
            var bossQuestTable = DatabaseDefine.Master.EntityMBigHuntBossQuestTable;
            var bossQuest = bossQuestTable.FindByBigHuntBossQuestId(bigHuntBossQuestId);

            var bossTable = DatabaseDefine.Master.EntityMBigHuntBossTable;
            var boss = bossTable.FindByBigHuntBossId(bossQuest.BigHuntBossId);

            return GetBigHuntBossName(boss.NameBigHuntBossTextId);
        }

        private static string GetBigHuntBossName(int nameBigHuntBossTextId)
        {
            return string.Format(UserInterfaceTextKey.BigHunt.kBossNameFormat, nameBigHuntBossTextId).Localize();
        }
    }
}
