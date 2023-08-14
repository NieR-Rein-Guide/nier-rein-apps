using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorLimitContent
{
    private const string kLimitQuestBackgroundPath = "ui)quest)limit_content)limit_content_quest_bg{0:D6}";
    private const string kLimitQuestComingSoonBackgroundPath = "ui)quest)limit_content)limit_content_quest_coming_soon_bg";
    private const int kInvalidLimitContentSideStoryQuestId = -1;
    public static readonly int kInvalidLimitContentDeckGroupNumber = -1;

    public static DataLimitContentCharacter CreateDataLimitContentCharacter(int questId)
    {
        var eventQuest = CalculatorQuest.CreateEventQuestData(questId);

        var table = DatabaseDefine.Master.EntityMEventQuestChapterLimitContentRelationTable;
        var relation = table.FindByEventQuestChapterId(eventQuest.Quest.ChapterId);
        if (relation == null)
            return null;

        var table1 = DatabaseDefine.Master.EntityMEventQuestLimitContentTable;
        var limitQuest = table1.FindByEventQuestLimitContentId(relation.EventQuestLimitContentId);
        if (limitQuest == null)
            return null;

        return CreateDataLimitContentCharacter(limitQuest);
    }

    public static List<DataLimitContentCharacter> CreateDataLimitContentCharacters()
    {
        var characters = new List<DataLimitContentCharacter>();

        var table = DatabaseDefine.Master.EntityMEventQuestLimitContentTable;
        foreach (var limitQuest in table.All)
        {
            if (!CalculatorDateTime.IsWithinThePeriod(limitQuest.StartDatetime, limitQuest.EndDatetime))
                continue;

            var character = CreateDataLimitContentCharacter(limitQuest);
            if (character == null)
                continue;

            characters.Add(character);
        }

        return characters;
    }

    private static DataLimitContentCharacter CreateDataLimitContentCharacter(EntityMEventQuestLimitContent limitQuest)
    {
        var table1 = DatabaseDefine.Master.EntityMEventQuestChapterLimitContentRelationTable;
        var userTable = DatabaseDefine.User.EntityIUserQuestLimitContentStatusTable;

        var relations = table1.FindByEventQuestLimitContentId(limitQuest.EventQuestLimitContentId);
        if (relations.Count == 0)
            return null;

        var maxDifficulty = CalculatorOutgame.kMaxDifficulty;
        var minDifficulty = CalculatorOutgame.kMinDifficulty;
        var levelProgress = new Dictionary<DifficultyType, DataLimitContentLevelClearProgress>(maxDifficulty);

        var difficulties = CalculatorOutgame.kSortedDifficulties;
        foreach (var difficulty in difficulties)
        {
            var clearCount = 0;
            var levelCount = 0;

            foreach (var relation in relations)
            {
                levelCount++;

                var chapterQuests = CalculatorQuest.GenerateEventQuestData(relation.EventQuestChapterId, difficulty);
                if (chapterQuests.Count == 0)
                    continue;

                var limitStatus = userTable.FindByUserIdAndQuestId((CalculatorStateUser.GetUserId(), chapterQuests.Last().Quest.QuestId));
                if (limitStatus == null)
                {
                    if (difficulty != DifficultyType.NORMAL)
                        continue;

                    if (minDifficulty != CalculatorQuest.kInvalidQuestId)
                        continue;

                    minDifficulty = chapterQuests.Last().Quest.QuestId;
                }
                else
                {
                    if (limitStatus.LimitContentQuestStatusType != 1)
                        continue;

                    clearCount++;
                    if (difficulty == DifficultyType.NORMAL)
                        minDifficulty = limitStatus.QuestId;
                }
            }

            levelProgress[difficulty] = new DataLimitContentLevelClearProgress
            {
                LevelCount = levelCount,
                LevelClearCount = clearCount
            };
        }

        var costume = CalculatorCostume.CreateMaxDataOutgameCostume(limitQuest.CostumeId);

        return new DataLimitContentCharacter
        {
            EventQuestLimitContentId = limitQuest.EventQuestLimitContentId,
            SortOrder = limitQuest.SortOrder,
            LevelClearProgresses = levelProgress,

            Costume = costume,
            IsCostumeAcquired = CalculatorCostume.HasCostume(CalculatorStateUser.GetUserId(), limitQuest.CostumeId)

            //IsLock = ,
        };
    }

    public static List<DifficultyType> CreateLimitContentDifficulties(int eventQuestLimitContentId)
    {
        var table = DatabaseDefine.Master.EntityMEventQuestChapterLimitContentRelationTable;
        var relations = table.FindByEventQuestLimitContentId(eventQuestLimitContentId);

        if (relations.Count == 0)
            return null;

        var result = new List<DifficultyType>();
        foreach (var relation in relations)
        {
            var table1 = DatabaseDefine.Master.EntityMEventQuestChapterTable;
            var chapter = table1.FindByEventQuestChapterId(relation.EventQuestChapterId);

            var groupId = chapter.EventQuestSequenceGroupId;

            var table2 = DatabaseDefine.Master.EntityMEventQuestSequenceGroupTable;
            var groups = table2.FindRangeByEventQuestSequenceGroupIdAndDifficultyType((groupId, DifficultyType.UNKNOWN), (groupId, DifficultyType.EX_HARD));
            if (groups.Count == 0)
                continue;

            var sequenceGroup = groups[0];
            if (sequenceGroup.EventQuestSequenceGroupId != chapter.EventQuestSequenceGroupId)
                continue;

            foreach (var group in groups)
                result.Add(group.DifficultyType);
        }

        return result.Distinct().OrderBy(x => x).ToList();
    }

    public static List<DataLimitContentLevel> CreateDataLimitContentLevels(int eventQuestLimitContentId, DifficultyType difficultyType)
    {
        var table = DatabaseDefine.Master.EntityMEventQuestChapterLimitContentRelationTable;
        var relations = table.FindByEventQuestLimitContentId(eventQuestLimitContentId);
        if (relations.Count == 0)
            return null;

        var result = new List<DataLimitContentLevel>();
        var userId = CalculatorStateUser.GetUserId();

        foreach (var relation in relations)
        {
            var level = CreateDataLimitContentLevel(userId, relation.EventQuestChapterId, difficultyType);
            if (level == null)
                continue;

            result.Add(level);
        }

        return result;
    }

    public static DataLimitContentLevel CreateDataLimitContentLevel(long userId, int eventQuestChapterId, DifficultyType difficultyType)
    {
        var chapter = CalculatorQuest.GetEventQuestChapter(eventQuestChapterId);
        var chapterQuests = CalculatorQuest.GenerateEventQuestData(eventQuestChapterId, difficultyType);
        if (chapterQuests.Count == 0)
            return null;

        var questClearCount = 0;
        var fieldEffectGroupIds = new SortedSet<int>();
        foreach (var chapterQuest in chapterQuests)
        {
            fieldEffectGroupIds.Add(chapterQuest.Quest.EntityQuest.FieldEffectGroupId);

            //var questStatus = table.FindByUserIdAndQuestId((userId, chapterQuest.Quest.QuestId));
            //if (questStatus != null && questStatus.LimitContentQuestStatusType == 1)
            if (chapterQuest.IsClearQuest)
                questClearCount++;
        }

        // Evaluate lock condition
        var isLock = false;
        var lockText = string.Empty;

        var unlockCondId = GetLimitContentLevelUnlockEvaluateConditionId(eventQuestChapterId, difficultyType);
        if (unlockCondId != CalculatorEvaluateCondition.kInvalidEvaluateConditionId)
        {
            if (!CalculatorEvaluateCondition.EvaluateCondition(userId, unlockCondId))
            {
                isLock = true;
                //lockText =;
            }
        }

        var lastQuest = chapterQuests.Last().Quest.EntityQuest;
        return new DataLimitContentLevel
        {
            EventQuestChapterId = eventQuestChapterId,
            //SortOrder = ,
            QuestCount = chapterQuests.Count,
            QuestClearCount = questClearCount,
            LevelClearReward = CalculatorQuest.GenerateFirstReward(lastQuest.QuestFirstClearRewardGroupId),
            LevelName = chapter.EventQuestName,

            IsLock = isLock,
            LockText = lockText,

            IsClear = questClearCount == chapterQuests.Count,

            FieldEffects = CalculatorQuest.GenerateQuestFieldEffectData(fieldEffectGroupIds.Min)
        };
    }

    public static int GetLimitContentLevelUnlockEvaluateConditionId(int eventQuestChapterId, DifficultyType difficultyType)
    {
        var table = DatabaseDefine.Master.EntityMEventQuestChapterDifficultyLimitContentUnlockTable;
        if (!table.TryFindByEventQuestChapterIdAndDifficultyType((eventQuestChapterId, difficultyType), out var unlockCond))
            return CalculatorEvaluateCondition.kInvalidEvaluateConditionId;

        return unlockCond.UnlockEvaluateConditionId;
    }
}
