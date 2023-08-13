using NCrontab;
using NierReincarnation.Core.Custom;
using NierReincarnation.Core.Dark.Calculator.Factory;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.MasterMemory;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.Subsystem.Serval;
using System.Text.RegularExpressions;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorQuest
{
    public static readonly int kInvalidChapterId;
    public static readonly int kInvalidQuestId;
    private const int kInvalidSeasonId = 0;
    private const int kInvalidQuestMissionConditionGroupId = 0;
    private const int kNotFindEventId = 0;
    private const long kMinuteToMilliSeconds = 60000;
    private const int kQuestStringCapacity = 256;
    private const int kQuestScheduleWarningCount = 1000;
    private const int kDefaultSeasonSortOrder = 1;
    private const int kCronLastMinuteDiff = 1;
    private static readonly Regex kTimeTableRegex = new("\\*");
    private const int kRegexReplaceCount = 1;
    private const int kDailyOnlyOnce = 1;
    private const int kCharacterExQuestChapterCapacity = 2;
    private const DifficultyType kDailyQuestDifficultyType = DifficultyType.NORMAL;
    private static readonly ValueTuple<int, int> kInvalidChapterIdAndQuestId = new(0, 0);
    private const int kDisplayChapterListMinCount = 2;
    private const int kLimitDailyQuestClearableCount = 1;
    private const int kLimitDailyChapterQuestCount = 1;
    private const int kLimitDailyQuestIndex = 0;
    private static readonly List<EntityMMainQuestSequence> GenericMainQuestSeqList = new();
    private static readonly List<EntityMEventQuestSequence> GenericEventQuestSeqList = new();
    public static readonly float kAutoTransitionCount = 3f;
    public static readonly int kMaxAutoAvailableCount = 10;

    public static bool HasScenario(EntityMQuest quest) => quest != null ? quest.StoryQuestTextId != 0 : throw new NullReferenceException();

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

    public static string GenerateMainQuestStillSpriteAssetName(int mainQuestChapterId, int questOrder)
    {
        throw new NotImplementedException();
    }

    public static ValueTuple<string, string> GenerateMainQuestPoemSpriteAssetName(int mainQuestChapterId, int questOrder)
    {
        throw new NotImplementedException();
    }

    public static bool GenerateSeasonTextPoemSpriteAssetName(ref string originalAssetName)
    {
        throw new NotImplementedException();
    }

    public static string GenerateMainQuestIconAssetName(int mainQuestChapterId, int questOrder)
    {
        throw new NotImplementedException();
    }

    public static bool IsPlayedSeasonId(int seasonId)
    {
        throw new NotImplementedException();
    }

    //public static List<ChapterButtonVerticalTabData> GenerateMainQuestChapterButtonData()
    //{
    //    throw new NotImplementedException();
    //}

    public static bool ExistBattleWithMainQuestSequenceGroupId(int mainQuestSequenceGroupId)
    {
        throw new NotImplementedException();
    }

    public static List<int> GenerateUnlockSeasonList()
    {
        throw new NotImplementedException();
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

    public static EventQuestData CreateEventQuestData(long userId, IQuest eventQuest, Action<EventQuestData> onQuestButtonTap, out bool isLock)
    {
        var questId = eventQuest.QuestId;
        var masterQuest = eventQuest.EntityQuest;

        isLock = IsQuestLocked(masterQuest, userId, out var isClear, out var isAvailable);

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

    public static List<EventQuestData> GenerateEndQuestData(int endQuestChapterId, Action<EventQuestData> onQuestButtonTap)
    {
        throw new NotImplementedException();
    }

    public static LimitDailyQuestData CreateLimitDailyQuestData(long userId, IQuest eventQuest)
    {
        var isClear = IsClearQuest(eventQuest.QuestId, userId);
        var canPlay = CanPlayQuestCheckCount(userId, eventQuest.QuestId, kLimitDailyQuestClearableCount);

        var entityQuest = eventQuest.EntityQuest;
        var isUnlocked = IsUnlockedQuest(entityQuest.QuestId, userId);

        var sceneId = CreateQuestFieldSceneList(eventQuest.QuestId).Select(x => x.QuestSceneId).FirstOrDefault();

        return new LimitDailyQuestData
        {
            Quest = eventQuest,
            AttributeType = GetFirstQuestDisplayAttributeType(entityQuest.QuestDisplayAttributeGroupId),
            Stamina = entityQuest.Stamina,
            RecommendPower = entityQuest.RecommendedDeckPower,

            Campaigns = CalculatorCampaign.CreateDataQuestCampaign(eventQuest),
            MissionData = GetMissionData(eventQuest.QuestId, entityQuest.QuestMissionGroupId, userId),
            QuestDropMaterials = GetEventQuestDisplayPossessionItemData(eventQuest.ChapterId).ToArray(),
            QuestFirstReward = GenerateFirstReward(entityQuest.QuestFirstClearRewardGroupId),

            IsClearQuest = isClear,
            IsLock = !isUnlocked,
            IsDailyQuestCleared = !canPlay,

            SceneId = sceneId
        };
    }

    public static IQuest GetLimitDailyChapterQuest(int eventQuestChapterId)
    {
        var userId = CalculatorStateUser.GetUserId();
        var quests = GetEventQuestList(eventQuestChapterId, DifficultyType.NORMAL)
            .Where(x => IsValidEventQuestTerm(x.QuestId, ((EventQuest)x).EntityQuestChapter.EventQuestType, userId))
            .ToList();

        if (quests.Count != kLimitDailyChapterQuestCount)
            return null;

        if (quests.Count <= kLimitDailyQuestIndex)
            throw new ArgumentOutOfRangeException();

        return quests[kLimitDailyQuestIndex];
    }

    public static bool TryGetUnlockEndQuestNameList(int questId, int questChapterId, out List<string> releaseEndQuestNameList)
    {
        throw new NotImplementedException();
    }

    public static bool TryGetReleaseQuestNameFromAcquisitionWeaponId(int weaponId, out string releaseQuestName)
    {
        throw new NotImplementedException();
    }

    public static List<int> GetReleaseQuestIdList(int clearQuestId)
    {
        throw new NotImplementedException();
    }

    public static bool TryGetEventQuestType(int chapterId, out EventQuestType eventQuestType)
    {
        throw new NotImplementedException();
    }

    public static bool IsUnlockMenuMainQuest(int mainQuestId, int questReleaseConditionListId, long userId)
    {
        throw new NotImplementedException();
    }

    // CUSTOM: Made internal to reduce confusion in the public API
    internal static bool IsUnlockedQuestByQuestId(int questId, long userId)
    {
        var entityQuest = DatabaseDefine.Master.EntityMQuestTable.FindByQuestId(questId);

        return IsUnlockedQuest(entityQuest.QuestReleaseConditionListId, userId);
    }

    // CUSTOM: Made internal to reduce confusion in the public API
    // HINT: Checks if a quest is unlocked by conditions; Does not take into account progress or time to determine lock state
    internal static bool IsUnlockedQuest(int questReleaseConditionListId, long userId)
    {
        var condList = DatabaseDefine.Master.EntityMQuestReleaseConditionListTable.FindByQuestReleaseConditionListId(questReleaseConditionListId);
        var condGroups = DatabaseDefine.Master.EntityMQuestReleaseConditionGroupTable.All.Where(x => x.QuestReleaseConditionGroupId == condList.QuestReleaseConditionGroupId).OrderBy(x => x.SortOrder);

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

    public static DifficultyType GetReleaseDifficultyTypeByQuestId(int questId, bool isMainQuest = true)
    {
        throw new NotImplementedException();
    }

    public static bool TryGetNextQuestId(bool isMainQuest, int questId, out int nextQuestId, out int nextChapterId)
    {
        throw new NotImplementedException();
    }

    public static List<DataPossessionItem> GetEventQuestDisplayPossessionItemData(int eventQuestChapterId)
    {
        var entityChapter = DatabaseDefine.Master.EntityMEventQuestChapterTable.FindByEventQuestChapterId(eventQuestChapterId);
        var groups = DatabaseDefine.Master.EntityMEventQuestDisplayItemGroupTable.All.Where(x => x.EventQuestDisplayItemGroupId == entityChapter.EventQuestDisplayItemGroupId);

        List<DataPossessionItem> res = new();
        foreach (var group in groups)
        {
            res.Add(new DataPossessionItem
            {
                PossessionId = group.PossessionId,
                PossessionType = group.PossessionType,
                Count = 1
            });
        }

        return res;
    }

    //public static ValueTuple<ScreenState, int> GetEventQuestLinkTransitionData(int eventQuestChapterId)
    //{
    //    throw new NotImplementedException();
    //}

    public static bool TryGetEventQuestChapterDataFromShopId(int shopId, out int eventId, out EventQuestType eventQuestType)
    {
        throw new NotImplementedException();
    }

    public static bool IsReleaseEventChapter(int eventQuestChapterId)
    {
        throw new NotImplementedException();
    }

    private static bool TryGetMainQuestNextQuestId(int questId, out int nextQuestId)
    {
        throw new NotImplementedException();
    }

    private static bool TryGetEventQuestNextQuestId(int questId, out int nextQuestId, out int nextChapterId)
    {
        throw new NotImplementedException();
    }

    private static IEnumerable<int> GetDifficultyTypeList(int questId, bool isMainQuest = true)
    {
        throw new NotImplementedException();
    }

    private static List<IQuest> GetEventQuestList(int eventQuestChapterId, DifficultyType difficultyType)
    {
        var eventQuestChapter = DatabaseDefine.Master.EntityMEventQuestChapterTable.FindByEventQuestChapterId(eventQuestChapterId);
        var questGroup = DatabaseDefine.Master.EntityMEventQuestSequenceGroupTable.All
            .Where(x => x.EventQuestSequenceGroupId == eventQuestChapter.EventQuestSequenceGroupId)
            .FirstOrDefault(x => difficultyType == 0 || x.DifficultyType == difficultyType);
        if (questGroup == null)
            return new List<IQuest>();

        var quests = DatabaseDefine.Master.EntityMEventQuestSequenceTable.All.Where(x => x.EventQuestSequenceId == questGroup.EventQuestSequenceId).OrderBy(x => x.SortOrder);

        var result = new List<IQuest>();
        foreach (var quest in quests)
            result.Add(new EventQuest(eventQuestChapter, questGroup, quest, DatabaseDefine.Master.EntityMQuestTable.FindByQuestId(quest.QuestId)));

        return result;
    }

    public static List<IQuest> CreateEventQuestListInEndTerm(int eventQuestChapterId)
    {
        return GetEventQuestList(eventQuestChapterId, DifficultyType.NORMAL);
    }

    public static bool IsClearQuest(int questId, long userId) => DatabaseDefine.User.EntityIUserQuestTable.FindByUserIdAndQuestId((userId, questId))?.QuestStateType == 2;

    //public static QuestChapterClearProgress GetEventQuestClearChapterProgress(int eventQuestChapterId, DifficultyType difficulty)
    //{
    //    throw new NotImplementedException();
    //}

    public static bool IsChallengeQuest(int questId, long userId)
    {
        var userQuest = DatabaseDefine.User.EntityIUserQuestTable.FindByUserIdAndQuestId((userId, questId));
        return userQuest?.QuestStateType == 2 || userQuest?.QuestStateType == 4;
    }

    public static bool IsExpandMissionQuest(IQuest quest)
    {
        throw new NotImplementedException();
    }

    public static bool IsTowerQuest(int questId)
    {
        throw new NotImplementedException();
    }

    public static bool IsClearQuest(int questId) => IsClearQuest(questId, CalculatorStateUser.GetUserId());

    public static bool IsClearQuestFirstTime(int questId) => DatabaseDefine.User.EntityIUserQuestTable.FindByUserIdAndQuestId((CalculatorStateUser.GetUserId(), questId))?.ClearCount == 0;

    public static bool IsUnlockedEventQuest(EventQuestType eventQuestType)
    {
        throw new NotImplementedException();
    }

    public static bool IsUnlockMainQuestChapter(long userId, int mainChapterId)
    {
        var masterChapter = DatabaseDefine.Master.EntityMMainQuestChapterTable.FindByMainQuestChapterId(mainChapterId);
        var questSequenceGroup = DatabaseDefine.Master.EntityMMainQuestSequenceGroupTable.FindByMainQuestSequenceGroupIdAndDifficultyType((masterChapter.MainQuestSequenceGroupId, DifficultyType.NORMAL));
        var sequences = DatabaseDefine.Master.EntityMMainQuestSequenceTable.All.Where(x => x.MainQuestSequenceId == questSequenceGroup.MainQuestSequenceId);
        var quests = sequences.Select(x => DatabaseDefine.Master.EntityMQuestTable.FindByQuestId(x.QuestId));

        return quests.Any(x => IsUnlockedQuest(x.QuestReleaseConditionListId, userId));
    }

    private static bool IsReceivedReplayFlowReward(long userId, int questReplayFlowRewardGroupId) =>
        DatabaseDefine.User.EntityIUserQuestReplayFlowRewardGroupTable.TryFindByUserIdAndQuestReplayFlowRewardGroupId((userId, questReplayFlowRewardGroupId), out var _);

    public static ValueTuple<DifficultyType, int> GetLatestQuest()
    {
        throw new NotImplementedException();
    }

    public static DifficultyType GetCurrentReleaseMaxDifficulty(int mainQuestChapterId)
    {
        throw new NotImplementedException();
    }

    public static int GetAvailableQuestCount(int currentStamina, int consumeStamina, Dictionary<int, bool> useRecoverItemFlags)
    {
        throw new NotImplementedException();
    }

    //private static bool CanSummarizeReward(QuestReward reward)
    //{
    //    throw new NotImplementedException();
    //}

    public static bool CanPlayQuestCheckCount(long userId, int questId, int dailyClearableCount)
    {
        var table = DatabaseDefine.User.EntityIUserQuestTable;
        var userQuest = table.FindByUserIdAndQuestId((userId, questId));

        if (dailyClearableCount == 0 || userQuest == null)
            return true;

        if (userQuest.LastClearDatetime == 0)
            throw new ArgumentNullException("Quest has invalid clear time.");

        var isAfterToday = CalculatorDateTime.IsAfterTodaySpanningTime(userQuest.LastClearDatetime);
        return userQuest.DailyClearCount < dailyClearableCount || !isAfterToday;
    }

    public static int GetRemainingQuestCount(long userId, int questId, int dailyClearableCount)
    {
        throw new NotImplementedException();
    }

    public static bool IsDeckRestriction(long userId, int questId) => IsDeckRestriction(questId);

    public static bool IsDeckRestriction(int questId) => QuestDeckRestrictionGroupId(questId) != 0;

    public static bool IsDeckRestrictionUnlocked(long userId, int questDeckRestrictionGroupId)
    {
        throw new NotImplementedException();
    }

    public static DataDeckRestriction[] CreateDeckRestrictionList(long userId, int questId) => CreateDeckRestrictionList(questId);

    public static DataDeckRestriction[] CreateDeckRestrictionList(int questId)
    {
        var group = QuestDeckRestrictionGroupId(questId);
        if (group == 0)
            return null;

        var restrictions = DatabaseDefine.Master.EntityMQuestDeckRestrictionGroupTable.FindRangeByQuestDeckRestrictionGroupIdAndSlotNumber((group, 1), (group, DeckServal.CHARACTER_MAX_COUNT));

        return restrictions.Select(CreateDataDeckRestriction).ToArray();
    }

    private static DataDeckRestriction CreateDataDeckRestriction(EntityMQuestDeckRestrictionGroup entityMQuestDeckRestrictionGroup)
    {
        return new DataDeckRestriction(entityMQuestDeckRestrictionGroup.SlotNumber, entityMQuestDeckRestrictionGroup.QuestDeckRestrictionType, entityMQuestDeckRestrictionGroup.RestrictionValue);
    }

    private static int QuestDeckRestrictionGroupId(int questId)
    {
        var masterQuest = DatabaseDefine.Master.EntityMQuestTable.FindByQuestId(questId);

        return masterQuest.QuestDeckRestrictionGroupId;
    }

    public static List<EventQuestChapterData> GetEventQuestChapters(EventQuestMenuCategoryType categoryType)
    {
        return categoryType switch
        {
            EventQuestMenuCategoryType.CharacterExQuest => GetCharacterExQuestCategoryChapters(),
            EventQuestMenuCategoryType.EventDefault => GetEventQuestEventCategoryChapters(),
            _ => new()
        };
    }

    private static List<EventQuestChapterData> GetEventQuestEventCategoryChapters()
    {
        throw new NotImplementedException();
    }

    private static List<EventQuestChapterData> GetCharacterExQuestCategoryChapters()
    {
        throw new NotImplementedException();
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

    public static EventQuestChapterData GetValidEventQuestChapterData(int eventQuestChapterId)
    {
        throw new NotImplementedException();
    }

    public static bool IsValidChapterListEventQuestChapterTerm(EntityMEventQuestChapter eventQuestChapter) =>
        eventQuestChapter.EventQuestType == EventQuestType.GUERRILLA || IsValidEventQuestChapterTerm(eventQuestChapter);

    public static bool IsValidEventQuestChapterTerm(int eventQuestChapterId)
    {
        var table = DatabaseDefine.Master.EntityMEventQuestChapterTable;
        var element = table.FindByEventQuestChapterId(eventQuestChapterId);
        if (element == null)
            return false;

        return IsValidEventQuestChapterTerm(element);
    }

    public static bool IsValidEventQuestChapterTerm(EntityMEventQuestChapter eventQuestChapter)
    {
        var withinPeriod = CalculatorDateTime.IsWithinThePeriod(eventQuestChapter.StartDatetime, eventQuestChapter.EndDatetime);
        if (!withinPeriod)
            return false;

        return GetEventQuestList(eventQuestChapter.EventQuestChapterId, DifficultyType.UNKNOWN).Any();
    }

    public static bool IsValidEventQuestTerm(int eventQuestId, EventQuestType eventQuestType, long userId, long graceTimeMilliSeconds = 0)
    {
        if (eventQuestType == EventQuestType.GUERRILLA)
            return CalculatorGuerrillaQuest.IsValidGuerrillaQuestTerm(eventQuestId, userId);

        return IsValidEventQuestTerm(eventQuestId);
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

            var validCron = IsTermEventQuestCronTimeByCurrentTime(schedule.QuestScheduleCronExpression);
            if (validCron)
                return true;
        }

        return false;
    }

    public static bool HasClearedQuestInEventChapter(int eventQuestChapterId)
    {
        throw new NotImplementedException();
    }

    public static bool IsTermEventQuestCronTimeByCurrentTime(string questScheduleCronExpression)
    {
        var options = new CrontabSchedule.ParseOptions { IncludingSeconds = true };
        var cronSchedule = CrontabSchedule.Parse(questScheduleCronExpression, options);

        var now = CalculatorDateTime.GetTodayChangeDateTime().DateTime;

        var nextOccurrence = cronSchedule.GetNextOccurrence(now);
        return CalculatorDateTime.IsFuzzyEqualDateTime(nextOccurrence, now.AddMilliseconds(CalculatorDateTime.kUnixTimeSecond));
    }

    public static bool IsTermEventQuestCronTimeByDateTime(string questScheduleCronExpression, DateTime startTime, DateTime endTime)
    {
        throw new NotImplementedException();
    }

    private static int GetMaxClearChapterId(DifficultyType difficultyType)
    {
        throw new NotImplementedException();
    }

    //private static void GenerateQuestInfoDataBasic(long userId, IQuest quest, ref QuestInfoDataBasic questInfoDataBasic)
    //{
    //    throw new NotImplementedException();
    //}

    //public static void GenerateQuestInfoDataBasicBigHunt(long userId, IQuest quest, ref QuestInfoDataBasic questInfoDataBasic)
    //{
    //    throw new NotImplementedException();
    //}

    //public static QuestInfoData GenerateQuestInfoData(IQuest quest)
    //{
    //    throw new NotImplementedException();
    //}

    //private static QuestInfoData GenerateReplayFlowQuestInfoData(IQuest quest, int replayFlowQuestId)
    //{
    //    throw new NotImplementedException();
    //}

    public static DifficultyType GetMaxReplayFlowQuestDifficulty(int mainFlowQuestId)
    {
        throw new NotImplementedException();
    }

    //private static QuestResultData GetCurrentResultData(IQuest currentQuest, DataDeck currentDeck, bool isRentalDeck)
    //{
    //    throw new NotImplementedException();
    //}

    //public static CharacterData[] CreateCharacterDataArray(DataDeck deck, bool isRentalDeck)
    //{
    //    throw new NotImplementedException();
    //}

    //public static CharacterData CreateCharacterData(DataOutgameCostume costume, bool isRentalDeck)
    //{
    //    throw new NotImplementedException();
    //}

    private static DataDeck GetCurrentDeck(long userId, IQuest quest)
    {
        throw new NotImplementedException();
    }

    //private static List<ResultDropCellData> CreateDistinctResultDropCellDataList(QuestReward[] dropRewards)
    //{
    //    throw new NotImplementedException();
    //}

    //private static ResultDropCellData CreateResultDropCellData(QuestReward questReward, ResultItemType resultItemType, int rewardEffectId = 0)
    //{
    //    throw new NotImplementedException();
    //}

    public static int GetMainQuestSeasonId(int mainQuestRouteId) => DatabaseDefine.Master.EntityMMainQuestRouteTable.FindByMainQuestRouteId(mainQuestRouteId)?.MainQuestSeasonId ?? 0;

    public static int GetMainQuestSeasonIdByChapterId(int chapterId) => GetMainQuestSeasonId(DatabaseDefine.Master.EntityMMainQuestChapterTable.FindByMainQuestChapterId(chapterId)?.MainQuestRouteId ?? 0);

    //public static QuestAcquisitionData[] CalculatorObeliskAcquisitionData(QuestFirstClearRewardType questFirstClearRewardType)
    //{
    //    throw new NotImplementedException();
    //}

    //public static QuestAcquisitionData[] CalculatorObeliskAcquisitionData(int questSceneId)
    //{
    //    throw new NotImplementedException();
    //}

    //public static QuestAcquisitionData[] CreateFullResultObeliskAcquisitionDataWithId(bool isFirstClear, int questId, CancellationToken ct)
    //{
    //    throw new NotImplementedException();
    //}

    //private static QuestAcquisitionData[] CalculatorObeliskAcquisitionDataWithQuestId(int questId, QuestFirstClearRewardType questFirstClearRewardType)
    //{
    //    throw new NotImplementedException();
    //}

    //private static QuestAcquisitionData[] CalculatorObeliskAcquisitionDataWithQuestSceneId(int questSceneId)
    //{
    //    throw new NotImplementedException();
    //}

    public static bool IsUsableSkipTicket(int questId) => DatabaseDefine.Master.EntityMQuestTable.TryFindByQuestId(questId, out var quest) && quest.IsUsableSkipTicket;

    public static bool ExistsBattle(int questId)
    {
        throw new NotImplementedException();
    }

    public static bool CheckBattleOnly(int questId) => DatabaseDefine.Master.EntityMQuestSceneTable.All.Any(x => x.QuestId == questId && x.QuestResultType == QuestResultType.HALF_RESULT)
;

    private static bool IsCheckReleaseCondition(int questReleaseConditionId, QuestReleaseConditionType questReleaseConditionType, long userId)
    {
        return questReleaseConditionType switch
        {
            QuestReleaseConditionType.USER_LEVEL => IsCheckUserLevel(questReleaseConditionId, userId),
            QuestReleaseConditionType.CHARACTER_LEVEL => IsCheckCharacterLevel(questReleaseConditionId, userId),
            QuestReleaseConditionType.DECK_POWER => IsCheckDeckPower(questReleaseConditionId, userId),
            QuestReleaseConditionType.QUEST_CLEAR => IsCheckQuestClear(questReleaseConditionId, userId),
            QuestReleaseConditionType.WEAPON_ACQUISITION => IsCheckAcquisition(questReleaseConditionId, userId),
            QuestReleaseConditionType.BIG_HUNT_SCORE => IsCheckBigHuntScore(questReleaseConditionId, userId),
            _ => true,
        };
    }

    private static bool IsCheckDeckPower(int questReleaseConditionId, long userId)
    {
        var table = DatabaseDefine.Master.EntityMQuestReleaseConditionDeckPowerTable;
        var userDeckPwr = table.FindByQuestReleaseConditionId(questReleaseConditionId);

        var table1 = DatabaseDefine.User.EntityIUserDeckTypeNoteTable;
        return table1.All.Where(x => x.UserId == userId).Any(x => userDeckPwr.MaxDeckPower <= x.MaxDeckPower);
    }

    private static bool IsCheckUserLevel(int questReleaseConditionId, long userId)
    {
        var table = DatabaseDefine.Master.EntityMQuestReleaseConditionUserLevelTable;
        var condUserLvl = table.FindByQuestReleaseConditionId(questReleaseConditionId);

        var table1 = DatabaseDefine.User.EntityIUserStatusTable;
        return table1.FindByUserId(userId).Level >= condUserLvl.UserLevel;
    }

    private static bool IsCheckQuestClear(int questReleaseConditionId, long userId)
    {
        var table = DatabaseDefine.Master.EntityMQuestReleaseConditionQuestClearTable;
        var masterClear = table.FindByQuestReleaseConditionId(questReleaseConditionId);

        return IsClearQuest(masterClear.QuestId, userId);
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

    private static bool IsCheckAcquisition(int questReleaseConditionId, long userId)
    {
        var weaponAq = DatabaseDefine.Master.EntityMQuestReleaseConditionWeaponAcquisitionTable.FindByQuestReleaseConditionId(questReleaseConditionId);
        return DatabaseDefine.User.EntityIUserWeaponNoteTable.TryFindByUserIdAndWeaponId((userId, weaponAq.WeaponId), out _);
    }

    private static bool IsCheckBigHuntScore(int questReleaseConditionId, long userId)
    {
        var bigBoss = DatabaseDefine.Master.EntityMQuestReleaseConditionBigHuntScoreTable.FindByQuestReleaseConditionId(questReleaseConditionId);
        var highScore = CalculatorBigHuntQuest.GetHighScoreByBigHuntBossId(userId, bigBoss.BigHuntBossId);
        return bigBoss.NecessaryScore <= highScore;
    }

    public static QuestFieldEffectData[] GenerateQuestFieldEffectData(int fieldEffectGroupId)
    {
        var effectGroups = DatabaseDefine.Master.EntityMFieldEffectGroupTable.FindByFieldEffectGroupId(fieldEffectGroupId);

        var result = new QuestFieldEffectData[effectGroups.Count];
        for (var i = 0; i < effectGroups.Count; i++)
        {
            var effectGroup = effectGroups[i];
            result[i] = new QuestFieldEffectData
            {
                AbilityId = effectGroup.AbilityId,
                DefaultAbilityLevel = effectGroup.DefaultAbilityLevel,
                FieldEffectApplyScopeType = effectGroup.FieldEffectApplyScopeType,
                FieldEffectAssetId = effectGroup.FieldEffectAssetId,
                FieldEffectGroupId = effectGroup.FieldEffectGroupId
            };
        }

        return result;
    }

    private static bool IsCheckQuestChallenge(int questReleaseConditionId, long userId)
    {
        return DatabaseDefine.Master.EntityMQuestReleaseConditionQuestChallengeTable.FindByQuestReleaseConditionId(questReleaseConditionId) != null;
    }

    private static QuestMissionData[] GetMissionData(int questId, int questMissionGroupId, long userId)
    {
        List<QuestMissionData> result = new();

        var missionGroups = DatabaseDefine.Master.EntityMQuestMissionGroupTable.All.Where(x => x.QuestMissionGroupId == questMissionGroupId);

        foreach (var missionGroup in missionGroups)
        {
            result.Add(GenerateQuestMissionData(questId, missionGroup.QuestMissionId, userId));
        }

        return result.ToArray();
    }

    public static DataPossessionItem GenerateFirstReward(int questFirstClearRewardGroupId)
    {
        var rewardGroup = DatabaseDefine.Master.EntityMQuestFirstClearRewardGroupTable.All
            .Where(x => x.QuestFirstClearRewardType == QuestFirstClearRewardType.NORMAL && x.QuestFirstClearRewardGroupId == questFirstClearRewardGroupId)
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

    private static DataPossessionItem[] GeneratePickupReward(int questPickupRewardGroupId)
    {
        var battleRewardIds = DatabaseDefine.Master.EntityMQuestPickupRewardGroupTable.All
            .Where(x => x.QuestPickupRewardGroupId == questPickupRewardGroupId)
            .Select(x => x.BattleDropRewardId)
            .ToArray();

        return battleRewardIds.Select(x =>
        {
            var battleDrop = DatabaseDefine.Master.EntityMBattleDropRewardTable.FindByBattleDropRewardId(x);
            return new DataPossessionItem
            {
                PossessionId = battleDrop.PossessionId,
                PossessionType = battleDrop.PossessionType,
                Count = battleDrop.Count
            };
        }).ToArray();
    }

    //public static QuestBossData CreateQuestBossData(int questId)
    //{
    //    throw new NotImplementedException();
    //}

    //private static QuestBossData CreateQuestBigHuntBossData(int questId)
    //{
    //    throw new NotImplementedException();
    //}

    //private static bool TryCreateQuestBossDataByNpcDeck(EntityMBattleNpcDeck battleNpcDeck, int questId, int battleGroupId, int waveNumber, out QuestBossData questBossData)
    //{
    //    throw new NotImplementedException();
    //}

    public static List<EntityMQuestScene> CreateQuestFieldSceneList(int questId)
    {
        return DatabaseDefine.Master.EntityMQuestSceneTable.All.Where(x => x.QuestId == questId && x.QuestSceneType == QuestSceneType.FIELD).ToList();
    }

    private static bool IsNpcBoss(long npcId, string npcDeckCharacterUuid)
    {
        var battleNpc = DatabaseDefine.Master.EntityMBattleNpcDeckCharacterTypeTable.FindByBattleNpcIdAndBattleNpcDeckCharacterUuid((npcId, npcDeckCharacterUuid));

        return battleNpc?.BattleEnemyType == BattleEnemyType.BOSS;
    }

    private static bool IsNpcNormalEnemy(long npcId, string npcDeckCharacterUuid)
    {
        var battleNpc = DatabaseDefine.Master.EntityMBattleNpcDeckCharacterTypeTable.FindByBattleNpcIdAndBattleNpcDeckCharacterUuid((npcId, npcDeckCharacterUuid));

        return battleNpc?.BattleEnemyType == BattleEnemyType.NORMAL;
    }

    private static EntityMBattleNpcDeck GetEntityMBattleNpcDeck(EntityMBattleGroup entityMBattleGroup)
    {
        var battle = DatabaseDefine.Master.EntityMBattleTable.FindByBattleId(entityMBattleGroup.BattleId);
        return DatabaseDefine.Master.EntityMBattleNpcDeckTable.FindByBattleNpcIdAndDeckTypeAndBattleNpcDeckNumber((battle.BattleNpcId, DeckType.QUEST, battle.BattleNpcDeckNumber));
    }

    //private static QuestBossData GenerateQuestBossData(long npcId, string npcDeckCharacterUuid, int questId, int battleGroupId, int waveNumber, bool isBoss = true)
    //{
    //    throw new NotImplementedException();
    //}

    private static bool TryGetBossName(int questId, out string bossDescriptionText)
    {
        bossDescriptionText = string.Format(UserInterfaceTextKey.Quest.kBossName, questId).Localize();

        return !string.IsNullOrEmpty(bossDescriptionText);
    }

    private static bool TryGetBossDescription(int questId, out string bossDescriptionText)
    {
        bossDescriptionText = string.Format(UserInterfaceTextKey.Quest.kBossDescription, questId).Localize();

        return !string.IsNullOrEmpty(bossDescriptionText);
    }

    private static bool TryGetSpecialEffectDescription(int battleGroupId, int waveNumber, out string specialEffectDescriptionText)
    {
        throw new NotImplementedException();
    }

    public static int GetChapterCharacterId(int eventQuestChapterId) => DatabaseDefine.Master.EntityMEventQuestChapterCharacterTable
        .FindByEventQuestChapterId(eventQuestChapterId)?.CharacterId ?? 0;

    public static int GetMainQuestSeasonSortOrder(int seasonId) => GetEntityMMainQuestSeason(mainQuestSeasonId: seasonId)?.SortOrder ?? 0;

    public static int GetAutoLatestChapterId() => DatabaseDefine.User.EntityIUserQuestAutoOrbitTable.FindByUserId(CalculatorStateUser.GetUserId())?.ChapterId ?? 0;

    public static int GetAutoLatestQuestId() => DatabaseDefine.User.EntityIUserQuestAutoOrbitTable.FindByUserId(CalculatorStateUser.GetUserId())?.QuestId ?? 0;

    public static bool IsValidStartEventQuestTerm(long userId, int chapterId, int questId, long graceTimeMilliSeconds = 0, bool withCheckCron = true)
    {
        if (!IsWithinEventChapterTerm(chapterId, graceTimeMilliSeconds) || !TryGetEventQuestType(chapterId, out var eventQuestType))
        {
            return false;
        }

        if (!withCheckCron)
        {
            return IsWithinQuestTerm(questId, graceTimeMilliSeconds);
        }

        return IsValidEventQuestTerm(questId, eventQuestType, userId, graceTimeMilliSeconds);
    }

    private static long GetQuestRestartGraceTimeMilliSeconds() => kMinuteToMilliSeconds * Config.GetQuestRestartGraceTimeAfterEvent();

    public static int GetDifficultyTypeByMainQuestId(int questId)
    {
        throw new NotImplementedException();
    }

    public static int GetDifficultyTypeByEventQuestId(int questId) => (int?)(CreateEventQuestData(questId)?.Quest.DifficultyType) ?? (int)DifficultyType.UNKNOWN;

    public static (int, int) GetValidDailyQuestChapterIdAndQuestId(IEnumerable<int> eventQuestChapterIds)
    {
        var entityChapter = eventQuestChapterIds
            .Select(x => DatabaseDefine.Master.EntityMEventQuestChapterTable.FindByEventQuestChapterId(x))
            .FirstOrDefault(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime));

        if (entityChapter == null)
            return kInvalidChapterIdAndQuestId;

        var seqGroup = DatabaseDefine.Master.EntityMEventQuestSequenceGroupTable
            .FindByEventQuestSequenceGroupIdAndDifficultyType((entityChapter.EventQuestSequenceGroupId, kDailyQuestDifficultyType));

        var sequences = DatabaseDefine.Master.EntityMEventQuestSequenceTable.All.Where(x => x.EventQuestSequenceId == seqGroup.EventQuestSequenceId);

        foreach (var sequence in sequences)
        {
            var schedules = DatabaseDefine.Master.EntityMQuestScheduleCorrespondenceTable.All.Where(x => x.QuestId == sequence.QuestId);
            foreach (var scheduleCorrespondence in schedules)
            {
                var schedule = DatabaseDefine.Master.EntityMQuestScheduleTable.All.FirstOrDefault(x => scheduleCorrespondence.QuestScheduleId == x.QuestScheduleId && CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime));
                if (schedule == null)
                    continue;

                var isCurrentTerm = IsTermEventQuestCronTimeByCurrentTime(schedule.QuestScheduleCronExpression);
                if (!isCurrentTerm)
                    continue;

                return (entityChapter.EventQuestChapterId, sequence.QuestId);
            }
        }

        return kInvalidChapterIdAndQuestId;
    }

    private static bool IsWithinEventChapterTerm(int chapterId, long graceTimeMilliSeconds = 0)
    {
        throw new NotImplementedException();
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

    public static QuestType GetQuestTypeByQuestId(int questId)
    {
        throw new NotImplementedException();
    }

    public static List<Term> GetCurrentEventChapterTodayTimeTable(int eventQuestChapterId)
    {
        var chapterQuests = GenerateEventQuestData(eventQuestChapterId, DifficultyType.NORMAL);
        var distinctTimes = chapterQuests
            .SelectMany(x => GetCurrentQuestTodayTimeTable(x.Quest.QuestId))
            .DistinctBy(x => x.Start);
        return distinctTimes.OrderBy(x => x.Start).ToList();
    }

    private static List<Term> GetCurrentQuestTodayTimeTable(int questId)
    {
        var table = DatabaseDefine.Master.EntityMQuestScheduleCorrespondenceTable;
        var terms = table.All.Where(x => x.QuestId == questId).ToArray();
        if (!terms.Any())
            return new List<Term> { Term.CurrentDay };

        var result = new List<Term>();

        var unixNow = CalculatorDateTime.UnixTimeNow();
        var schedules = terms.Select(x => DatabaseDefine.Master.EntityMQuestScheduleTable.FindByQuestScheduleId(x.QuestScheduleId));
        foreach (var schedule in schedules.Where(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime, unixNow)))
        {
            var replacedCron = kTimeTableRegex.Replace(schedule.QuestScheduleCronExpression, "", kRegexReplaceCount);
            var parsedCron = CrontabSchedule.Parse(replacedCron);

            var now = CalculatorDateTime.GetTodayChangeDateTime().DateTime;
            var tmr = CalculatorDateTime.GetNextChangeDateTime().DateTime;

            var firstOccurrence = parsedCron.GetNextOccurrences(now, tmr).FirstOrDefault();
            var lastOccurrence = parsedCron.GetNextOccurrences(now, tmr).LastOrDefault();

            if (CalculatorDateTime.IsFuzzyEqualDateTime(firstOccurrence, now.AddMinutes(1)))
                firstOccurrence = now;

            lastOccurrence = lastOccurrence.AddMinutes(kCronLastMinuteDiff);
            if (CalculatorDateTime.IsFuzzyEqualDateTime(firstOccurrence, new DateTime()))
                continue;

            // HINT: CRON expressions are given based on different timezones based on the target region of the game
            result.Add(DateTimeConversions.GetGuerillaTerm(firstOccurrence, lastOccurrence));
        }

        return result;
    }

    public static int GetMainQuestChapterId(int questId)
    {
        throw new NotImplementedException();
    }

    public static int GetEventQuestChapterId(int questId)
    {
        throw new NotImplementedException();
    }

    public static List<int> GenerateQuestMissionConditionValues(int questMissionConditionValueGroupId)
    {
        if (questMissionConditionValueGroupId == kInvalidQuestMissionConditionGroupId)
            return null;

        var range = DatabaseDefine.Master.EntityMQuestMissionConditionValueGroupTable
            .FindRangeByQuestMissionConditionValueGroupIdAndSortOrder((questMissionConditionValueGroupId, int.MinValue), (questMissionConditionValueGroupId, int.MaxValue));

        List<int> result = new();
        foreach (var item in range)
        {
            result.Add(item.ConditionValue);
        }

        return result;
    }

    public static int GetUserMainQuestMainFlowRouteId(long userId) =>
        DatabaseDefine.User.EntityIUserMainQuestMainFlowStatusTable.FindByUserId(userId)?.CurrentMainQuestRouteId
            ?? SearchFirstSeasonEntityMMainQuestRoute().MainQuestRouteId;

    public static int GetUserMainQuestMainFlowSeasonId(long userId)
    {
        return GetMainQuestSeasonId(GetUserMainQuestMainFlowRouteId(userId));
    }

    private static EntityMMainQuestRoute SearchFirstSeasonEntityMMainQuestRoute()
    {
        throw new NotImplementedException();
    }

    private static bool TryGetEntityMainQuestSequenceWithQuestId(int questId, out EntityMMainQuestSequence mainQuestSequenceEntity)
    {
        throw new NotImplementedException();
    }

    private static bool TryGetEntityEventQuestSequenceWithQuestId(int questId, out EntityMEventQuestSequence eventQuestSequenceEntity)
    {
        throw new NotImplementedException();
    }

    private static void AddRangeMainQuestSeqList(RangeView<EntityMMainQuestSequence> sequenceQuestEntities)
    {
        GenericMainQuestSeqList.Clear();
        GenericMainQuestSeqList.AddRange(sequenceQuestEntities);
        GenericMainQuestSeqList.Sort();
        //GenericMainQuestSeqList.Sort(SequenceAscendingComparer);
    }

    private static void AddRangeEventQuestSeqList(RangeView<EntityMEventQuestSequence> sequenceQuestEntities)
    {
        GenericEventQuestSeqList.Clear();
        GenericEventQuestSeqList.AddRange(sequenceQuestEntities);
        GenericMainQuestSeqList.Sort();
        //GenericEventQuestSeqList.Sort(SequenceAscendingComparer);
    }

    public static DifficultyType GetMainOrReplayFlowDifficulty(int questId)
    {
        throw new NotImplementedException();
    }

    public static DifficultyType GetClampReplayQuestDifficultyType(int questId)
    {
        throw new NotImplementedException();
    }

    public static bool IsUnlockDifficulty(DifficultyType difficultyType)
    {
        if (difficultyType == DifficultyType.VERY_HARD)
        {
            return IsClearQuest(Config.GetUnlockVeryHardQuestQuestId(), CalculatorStateUser.GetUserId());
        }
        else if (difficultyType == DifficultyType.HARD)
        {
            return IsClearQuest(Config.GetUnlockHardQuestQuestId(), CalculatorStateUser.GetUserId());
        }

        return true;
    }

    public static bool IsQuestUnlocked(IQuest quest)
    {
        return IsUnlockMenuMainQuest(quest.QuestId, quest.EntityQuest.QuestReleaseConditionListId, CalculatorStateUser.GetUserId());
    }

    public static bool TryGetReplayFlowQuest(int currentQuestId, DifficultyType difficultyType, out IQuest quest)
    {
        throw new NotImplementedException();
    }

    public static int GetDefaultMainQuestRouteSortOrder(int mainQuestSeasonId)
    {
        var routes = DatabaseDefine.Master.EntityMMainQuestRouteTable.All
            .Where(x => x.MainQuestSeasonId == mainQuestSeasonId && x.SortOrder != 0)
            .OrderBy(x => x.SortOrder);

        return routes.FirstOrDefault()?.SortOrder ?? 0;
    }

    public static int GetMainQuestRouteId(long userId, int mainQuestSeasonId) => GetEntityIUserMainQuestSeasonRoute(userId, mainQuestSeasonId)?.MainQuestRouteId ?? 0;

    public static int GetMainQuestRouteId(int mainQuestChapterId) => DatabaseDefine.Master.EntityMMainQuestRouteTable.FindByMainQuestRouteId(mainQuestChapterId)?.MainQuestRouteId ?? 0;

    public static bool IsEventQuestDailyGroupChapter(int eventQuestChapterId) => DatabaseDefine.Master.EntityMEventQuestDailyGroupTargetChapterTable.All
        .Any(x => x.EventQuestChapterId == eventQuestChapterId);

    private static EntityMMainQuestRoute GetEntityMMainQuestRoute(int mainQuestRouteId) =>
        DatabaseDefine.Master.EntityMMainQuestRouteTable.FindByMainQuestRouteId(mainQuestRouteId);

    private static EntityMMainQuestSeason GetEntityMMainQuestSeason(int mainQuestSeasonId) =>
        DatabaseDefine.Master.EntityMMainQuestSeasonTable.FindByMainQuestSeasonId(mainQuestSeasonId);

    private static EntityIUserMainQuestSeasonRoute GetEntityIUserMainQuestSeasonRoute(long userId, int mainQuestSeasonId) =>
        DatabaseDefine.User.EntityIUserMainQuestSeasonRouteTable.FindByUserIdAndMainQuestSeasonId((userId, mainQuestSeasonId));

    public static string GetMainQuestChapterNameByQuestId(int mainQuestId)
    {
        throw new NotImplementedException();
    }

    public static string GetMainQuestChapterNameByChapterId(int mainQuestChapterId)
    {
        throw new NotImplementedException();
    }

    public static string GetMainQuestChapterNumberName(EntityMMainQuestChapter entityMMainQuestChapter)
    {
        var masterRoute = DatabaseDefine.Master.EntityMMainQuestRouteTable.FindByMainQuestRouteId(entityMMainQuestChapter.MainQuestRouteId);
        var masterSeason = DatabaseDefine.Master.EntityMMainQuestSeasonTable.FindByMainQuestSeasonId(masterRoute.MainQuestSeasonId);

        return GetMainQuestChapterNumberName(masterSeason.SortOrder, masterRoute.SortOrder, entityMMainQuestChapter.SortOrder);
    }

    public static string GetQuestName(int nameTextId) => string.Format(UserInterfaceTextKey.Quest.kQuestNameTextKey, nameTextId).Localize();

    public static string GetQuestNameWithCharacterName(string characterName, int nameTextId) => $"{characterName} {GetQuestName(nameTextId)}";

    public static string GetEventQuestChapterNameByQuestId(int eventQuestId) => GetEventQuestChapterName(eventQuestId, EventQuestType.MARATHON);

    public static string GetEventQuestChapterName(int nameTextId, EventQuestType eventQuestType = EventQuestType.UNKNOWN)
    {
        return eventQuestType switch
        {
            EventQuestType.DAY_OF_THE_WEEK => UserInterfaceTextKey.Quest.kEventQuestDayOfTheWeek.Localize(),
            EventQuestType.GUERRILLA => UserInterfaceTextKey.Quest.kEventQuestGuerrilla.Localize(),
            EventQuestType.CHARACTER => UserInterfaceTextKey.Quest.kEventQuestCharacter.Localize(),
            EventQuestType.END_CONTENTS => UserInterfaceTextKey.Quest.kEventQuestEndContents.Localize(),
            _ => string.Format(UserInterfaceTextKey.Quest.kEventChapterTitle, nameTextId).Localize(),
        };
    }

    private static string GetDungeonChapterName(int nameTextId) => string.Format(UserInterfaceTextKey.Quest.kEventChapterTitleDungeon, nameTextId).Localize();

    private static string GetMainQuestChapterName(int seasonSortOrder, int routeSortOrder, int chapterSortOrder) =>
        string.Format(UserInterfaceTextKey.Quest.kMainChapterTitle, seasonSortOrder, routeSortOrder, chapterSortOrder).Localize();

    private static string GetMainQuestChapterNameWithTextAssetId(int seasonSortOrder, int routeSortOrder, int chapterSortOrder, int textAssetId) =>
        string.Format(UserInterfaceTextKey.Quest.kMainChapterTitleWithTextAssetId, seasonSortOrder, routeSortOrder, chapterSortOrder, textAssetId).Localize();

    private static string GetMainQuestChapterNumberName(int seasonSortOrder, int routeSortOrder, int chapterSortOrder) =>
        string.Format(UserInterfaceTextKey.Quest.kMainChapterNumber, seasonSortOrder, routeSortOrder, chapterSortOrder).Localize();

    public static string GetMainQuestSeasonName(int seasonSortOrder) => string.Format(UserInterfaceTextKey.Quest.kMainSeasonTitle, seasonSortOrder).Localize();

    public static (string, string) GetMainQuestChapterText(int mainQuestRouteId, int mainQuestSortOrder)
    {
        var masterRoute = DatabaseDefine.Master.EntityMMainQuestRouteTable.FindByMainQuestRouteId(mainQuestRouteId);
        var seasonSortOrder = GetMainQuestSeasonSortOrder(masterRoute.MainQuestSeasonId);
        var chapterNumber = GetMainQuestChapterNumberName(seasonSortOrder, masterRoute.SortOrder, mainQuestSortOrder);
        var chapterName = GetMainQuestChapterName(seasonSortOrder, masterRoute.SortOrder, mainQuestSortOrder);

        return (chapterNumber, chapterName);
    }

    public static string GetMainQuestChapterTextWithTextAssetId(int mainQuestRouteId, int mainQuestSortOrder, int textAssetId)
    {
        var masterRoute = DatabaseDefine.Master.EntityMMainQuestRouteTable.FindByMainQuestRouteId(mainQuestRouteId);
        var seasonSortOrder = GetMainQuestSeasonSortOrder(masterRoute.MainQuestSeasonId);

        return GetMainQuestChapterNameWithTextAssetId(seasonSortOrder, masterRoute.SortOrder, mainQuestSortOrder, textAssetId);
    }

    private static string GetReleaseConditionText(int questReleaseConditionId, QuestReleaseConditionType questReleaseConditionType, int chapterId)
    {
        return questReleaseConditionType switch
        {
            QuestReleaseConditionType.USER_LEVEL => "",
            _ => string.Empty
        };
    }

    private static string GetDeckPowerConditionText(int questReleaseConditionId)
    {
        var questReleaseCondition = DatabaseDefine.Master.EntityMQuestReleaseConditionDeckPowerTable.FindByQuestReleaseConditionId(questReleaseConditionId);
        return UserInterfaceTextKey.Quest.kDeckPowerLock.LocalizeWithParams(questReleaseCondition.MaxDeckPower);
    }

    private static string GetUserLevelConditionText(int questReleaseConditionId)
    {
        var questReleaseCondition = DatabaseDefine.Master.EntityMQuestReleaseConditionUserLevelTable.FindByQuestReleaseConditionId(questReleaseConditionId);
        return UserInterfaceTextKey.Quest.kUserLevelLock.LocalizeWithParams(questReleaseCondition.UserLevel);
    }

    private static string GetCharacterLevelConditionText(int questReleaseConditionId)
    {
        var questReleaseCondition = DatabaseDefine.Master.EntityMQuestReleaseConditionCharacterLevelTable.FindByQuestReleaseConditionId(questReleaseConditionId);
        return UserInterfaceTextKey.Quest.kCharacterLevelLock.LocalizeWithParams(CalculatorCharacter.GetCharacterName(questReleaseCondition.CharacterId), questReleaseCondition.CharacterLevel);
    }

    private static string GetBigHuntScoreConditionText(int questReleaseConditionId)
    {
        var questReleaseCondition = DatabaseDefine.Master.EntityMQuestReleaseConditionBigHuntScoreTable.FindByQuestReleaseConditionId(questReleaseConditionId);
        return UserInterfaceTextKey.BigHunt.kBigHuntLockScore.LocalizeWithParams(questReleaseCondition.NecessaryScore);
    }

    private static string GetQuestClearConditionText(int questReleaseConditionId)
    {
        var questReleaseCondition = DatabaseDefine.Master.EntityMQuestReleaseConditionQuestClearTable.FindByQuestReleaseConditionId(questReleaseConditionId);
        return GetClearQuestText(questReleaseCondition.QuestId);
    }

    private static string GetEventQuestClearConditionText(int questReleaseConditionId, int chapterId)
    {
        var questReleaseCondition = DatabaseDefine.Master.EntityMQuestReleaseConditionQuestClearTable.FindByQuestReleaseConditionId(questReleaseConditionId);
        var questText = GetClearQuestText(questReleaseCondition.QuestId);
        var chapter = DatabaseDefine.Master.EntityMEventQuestChapterTable.FindByEventQuestChapterId(chapterId);
        var chapterName = GetEventQuestChapterName(chapter.NameEventQuestTextId, EventQuestType.MARATHON);

        return $"{chapterName} {questText}";
    }

    public static string GetQuestClearUnlockText(int questId)
    {
        var questText = GetClearQuestText(questId);

        return UserInterfaceTextKey.Common.kUnlockTiming.LocalizeWithParams(questText);
    }

    private static string GetClearQuestText(int questId)
    {
        throw new NotImplementedException();
    }

    private static string GetMainQuestClearQuestText(EntityMQuest entityMQuest)
    {
        throw new NotImplementedException();
    }

    private static string GetEventQuestClearQuestText(EntityMQuest entityMQuest)
    {
        return UserInterfaceTextKey.Common.kClearQuestEventDifficulty.LocalizeWithParams(string.Format(UserInterfaceTextKey.Quest.kDifficulty, GetDifficultyTypeByEventQuestId(entityMQuest.QuestId)).Localize(),
            GetQuestName(entityMQuest.NameQuestTextId));
    }

    public static string GetClearChapterText(int chapterId) => GetClearChapterText(GetMainQuestChapterNameByChapterId(chapterId));

    public static string GetClearChapterText(string chapterNumberName) => UserInterfaceTextKey.Common.kClearQuestMainChapter.LocalizeWithParams(chapterNumberName);

    public static string GenerateMissionText(QuestMissionConditionType questMissionConditionType, int value, List<int> questMissionConditionValueList)
    {
        var missionTextKey = string.Format(UserInterfaceTextKey.Quest.kMissionMainTitleTextKey, (int)questMissionConditionType);
        string keyParam;

        switch (questMissionConditionType)
        {
            case QuestMissionConditionType.LESS_THAN_OR_EQUAL_X_PEOPLE_NOT_ALIVE:
                if (value == 0)
                    missionTextKey += UserInterfaceTextKey.Quest.kMissionMainTitleLimitedTextKeySuffix;

                keyParam = $"{value}";
                break;

            case QuestMissionConditionType.SPECIFIED_COSTUME_IS_IN_DECK:
                keyParam = CalculatorCostume.CostumeName(value);
                break;

            case QuestMissionConditionType.SPECIFIED_CHARACTER_IS_IN_DECK:
                keyParam = CalculatorCharacter.CharacterName(value);
                break;

            case QuestMissionConditionType.SPECIFIED_ATTRIBUTE_MAIN_WEAPON_IS_IN_DECK:
            case QuestMissionConditionType.SPECIFIED_ATTRIBUTE_WEAPON_IS_IN_DECK:
            case QuestMissionConditionType.SPECIFIED_ATTRIBUTE_MAIN_WEAPON_ALL_CHARACTER:
            case QuestMissionConditionType.SPECIFIED_ATTRIBUTE_WEAPON_ALL_CHARACTER:
            case QuestMissionConditionType.COMPANION_ATTRIBUTE:
                keyParam = CalculatorAttribute.GetAttributeText((AttributeType)value);
                break;

            case QuestMissionConditionType.COSTUME_SKILLFUL_WEAPON_ALL_CHARACTER:
            case QuestMissionConditionType.COSTUME_SKILLFUL_WEAPON_ANY_CHARACTER:
            case QuestMissionConditionType.WEAPON_MAN_SKILLFUL_WEAPON_ALL_CHARACTER:
            case QuestMissionConditionType.WEAPON_SKILLFUL_WEAPON_ALL_CHARACTER:
            case QuestMissionConditionType.WEAPON_MAN_SKILLFUL_WEAPON_ANY_CHARACTER:
            case QuestMissionConditionType.WEAPON_SKILLFUL_WEAPON_ANY_CHARACTER:
                keyParam = CalculatorWeaponType.GetWeaponTypeText(value);
                break;

            case QuestMissionConditionType.COSTUME_RARITY_EQ_ALL_CHARACTER:
            case QuestMissionConditionType.COSTUME_RARITY_GE_ALL_CHARACTER:
            case QuestMissionConditionType.COSTUME_RARITY_LE_ALL_CHARACTER:
            case QuestMissionConditionType.COSTUME_RARITY_EQ_ANY_CHARACTER:
            case QuestMissionConditionType.COSTUME_RARITY_GE_ANY_CHARACTER:
            case QuestMissionConditionType.COSTUME_RARITY_LE_ANY_CHARACTER:
            case QuestMissionConditionType.WEAPON_RARITY_EQ_ALL_CHARACTER:
            case QuestMissionConditionType.WEAPON_RARITY_GE_ALL_CHARACTER:
            case QuestMissionConditionType.WEAPON_RARITY_LE_ALL_CHARACTER:
            case QuestMissionConditionType.WEAPON_MAIN_RARITY_EQ_ALL_CHARACTER:
            case QuestMissionConditionType.WEAPON_MAIN_RARITY_GE_ALL_CHARACTER:
            case QuestMissionConditionType.WEAPON_MAIN_RARITY_LE_ALL_CHARACTER:
            case QuestMissionConditionType.WEAPON_RARITY_EQ_ANY_CHARACTER:
            case QuestMissionConditionType.WEAPON_RARITY_GE_ANY_CHARACTER:
            case QuestMissionConditionType.WEAPON_RARITY_LE_ANY_CHARACTER:
            case QuestMissionConditionType.WEAPON_MAIN_RARITY_EQ_ANY_CHARACTER:
            case QuestMissionConditionType.WEAPON_MAIN_RARITY_GE_ANY_CHARACTER:
            case QuestMissionConditionType.WEAPON_MAIN_RARITY_LE_ANY_CHARACTER:
            case QuestMissionConditionType.PARTS_RARITY_EQ:
            case QuestMissionConditionType.PARTS_RARITY_GE:
            case QuestMissionConditionType.PARTS_RARITY_LE:
                keyParam = CalculatorRarity.GetRarityName(value);
                break;

            case QuestMissionConditionType.COMPANION_ID:
                keyParam = CalculatorCompanion.CompanionName(value);
                break;

            case QuestMissionConditionType.COMPANION_CATEGORY:
                keyParam = CalculatorCompanion.GetCompanionCategoryName(value);
                break;

            case QuestMissionConditionType.PARTS_ID:
                keyParam = CalculatorMemory.MemoryName(value);
                break;

            case QuestMissionConditionType.PARTS_GROUP_ID:
                keyParam = CalculatorMemory.MemorySeriesName(value);
                break;

            case QuestMissionConditionType.CHARACTER_CONTAIN_ALL:
                var connectionWord = UserInterfaceTextKey.Quest.kQuestMissionAnd.Localize();
                keyParam = GenerateTextValueFromConditionValueList(questMissionConditionValueList, connectionWord, CalculatorCharacter.GetCharacterName);
                break;

            case QuestMissionConditionType.CHARACTER_CONTAIN_ANY:
                connectionWord = UserInterfaceTextKey.Quest.kQuestMissionOr.Localize();
                keyParam = GenerateTextValueFromConditionValueList(questMissionConditionValueList, connectionWord, CalculatorCharacter.GetCharacterName);
                break;

            case QuestMissionConditionType.COSTUME_CONTAIN_ALL:
                connectionWord = UserInterfaceTextKey.Quest.kQuestMissionAnd.Localize();
                keyParam = GenerateTextValueFromConditionValueList(questMissionConditionValueList, connectionWord, CalculatorCostume.CostumeName);
                break;

            case QuestMissionConditionType.COSTUME_CONTAIN_ANY:
                connectionWord = UserInterfaceTextKey.Quest.kQuestMissionOr.Localize();
                keyParam = GenerateTextValueFromConditionValueList(questMissionConditionValueList, connectionWord, CalculatorCostume.CostumeName);
                break;

            case QuestMissionConditionType.COSTUME_SKILLFUL_WEAPON_CONTAIN_ALL:
            case QuestMissionConditionType.WEAPON_MAN_SKILLFUL_WEAPON_CONTAIN_ALL:
            case QuestMissionConditionType.WEAPON_SKILLFUL_WEAPON_CONTAIN_ALL:
                connectionWord = UserInterfaceTextKey.Quest.kQuestMissionAnd.Localize();
                keyParam = GenerateTextValueFromConditionValueList(questMissionConditionValueList, connectionWord, CalculatorWeaponType.GetWeaponTypeText);
                break;

            case QuestMissionConditionType.COSTUME_SKILLFUL_WEAPON_CONTAIN_ANY:
            case QuestMissionConditionType.WEAPON_MAN_SKILLFUL_WEAPON_CONTAIN_ANY:
            case QuestMissionConditionType.WEAPON_SKILLFUL_WEAPON_CONTAIN_ANY:
                connectionWord = UserInterfaceTextKey.Quest.kQuestMissionOr.Localize();
                keyParam = GenerateTextValueFromConditionValueList(questMissionConditionValueList, connectionWord, CalculatorWeaponType.GetWeaponTypeText);
                break;

            case QuestMissionConditionType.ATTRIBUTE_MAIN_WEAPON_CONTAIN_ALL:
            case QuestMissionConditionType.ATTRIBUTE_WEAPON_CONTAIN_ALL:
                connectionWord = UserInterfaceTextKey.Quest.kQuestMissionAnd.Localize();
                keyParam = GenerateTextValueFromConditionValueList(questMissionConditionValueList, connectionWord, CalculatorAttribute.GetAttributeText);
                break;

            case QuestMissionConditionType.ATTRIBUTE_MAIN_WEAPON_CONTAIN_ANY:
            case QuestMissionConditionType.ATTRIBUTE_WEAPON_CONTAIN_ANY:
                connectionWord = UserInterfaceTextKey.Quest.kQuestMissionOr.Localize();
                keyParam = GenerateTextValueFromConditionValueList(questMissionConditionValueList, connectionWord, CalculatorAttribute.GetAttributeText);
                break;

            default:
                keyParam = $"{value}";
                break;
        }

        return missionTextKey.LocalizeWithParams(keyParam);
    }

    public static string GetQuestUnlockText(int releaseConditionQuestListId, int chapterId, QuestType questType)
    {
        if (questType != QuestType.EVENT_QUEST)
        {
        }

        return GetQuestUnlockConditionText(releaseConditionQuestListId, questType == QuestType.EVENT_QUEST ? chapterId : kInvalidChapterId) + UserInterfaceTextKey.Unlock.kUnLockBy.Localize();
    }

    public static string GetReplayQuestUnlockText(int releaseConditionQuestListId, DifficultyType difficultyType)
    {
        var unlockText = GetQuestUnlockConditionText(releaseConditionQuestListId);
        var unlockSuffix = difficultyType switch
        {
            DifficultyType.VERY_HARD => GetQuestClearUnlockText(Config.GetUnlockVeryHardQuestQuestId()),
            DifficultyType.HARD => GetQuestClearUnlockText(Config.GetUnlockHardQuestQuestId()),
            _ => string.Empty
        };

        return unlockText + (string.IsNullOrEmpty(unlockSuffix)
            ? UserInterfaceTextKey.Unlock.kUnLockBy.Localize()
            : UserInterfaceTextKey.Quest.kLockAndTextKey.Localize() + unlockSuffix + UserInterfaceTextKey.Unlock.kUnLockBy.Localize());
    }

    private static string GetQuestUnlockConditionText(int releaseConditionQuestListId, int chapterId)
    {
        throw new NotImplementedException();
    }

    public static string GetListMainQuestChapterName(EntityMMainQuestChapter entityMMainQuestChapter)
    {
        var chapterText = GetMainQuestChapterText(entityMMainQuestChapter.MainQuestRouteId, entityMMainQuestChapter.SortOrder);
        return chapterText.Item1 + chapterText.Item2;
    }

    public static string GetListMainQuestName(MainQuest quest)
    {
        var chapterText = GetMainQuestChapterText(quest.EntityQuestChapter.MainQuestRouteId, quest.EntityQuestChapter.SortOrder);
        var questName = GetQuestName(quest.EntityQuest.NameQuestTextId);
        string sortOrderText = quest.EntityQuestChapter.SortOrder != 0 ?
            quest.EntityQuestChapter.SortOrder.ToString() + " " : "";

        return $"{chapterText} {sortOrderText}{questName}";
    }

    public static string GetListEventQuestName(EventQuest quest)
    {
        // TODO: Partially broken
        string questName = quest.EntityQuestChapter.EventQuestType == EventQuestType.LIMIT_CONTENT || ((1 << (int)quest.EntityQuestChapter.EventQuestType) & 2240) != 0
            ? GetQuestName(quest.EntityQuest.NameQuestTextId)
            : GetQuestNameWithCharacterName(CalculatorCharacter.GetCharacterName(0), quest.EntityQuest.NameQuestTextId);
        var chapterName = GetEventQuestChapterName(quest.EntityQuestChapter.NameEventQuestTextId, quest.EntityQuestChapter.EventQuestType);

        return chapterName + " " + questName;
    }

    public static string GetEventQuestTypeNameTextKey(EventQuestType eventQuestType) => string.Format(UserInterfaceTextKey.Unlock.kEventFormat, eventQuestType);

    private static string GenerateTextValueFromConditionValueList(List<int> questMissionConditionValueList, string separateWord, Func<int, string> convertMethod)
    {
        var convertedItems = new List<string>();
        foreach (var conditionValue in questMissionConditionValueList)
            convertedItems.Add(convertMethod?.Invoke(conditionValue));

        var regex = new Regex(@"\<space=\d+\>");
        return string.Join(regex.Replace(separateWord, " "), convertedItems);
    }

    #region Custom

    public static List<EventQuestChapterData> GetAllEventQuestChapters()
    {
        return GetEventQuestChapters(EventQuestType.MARATHON, EventQuestType.HUNT, EventQuestType.DUNGEON,
                                     EventQuestType.DAY_OF_THE_WEEK, EventQuestType.GUERRILLA,
                                     EventQuestType.CHARACTER, EventQuestType.END_CONTENTS,
                                     EventQuestType.SPECIAL, EventQuestType.TOWER, EventQuestType.LIMIT_CONTENT, EventQuestType.LABYRINTH);
    }

    // CUSTOM: Get event quest chapters by type Filters out limit daily content, since it has to be called upon separately
    public static List<EventQuestChapterData> GetEventQuestChapters(params EventQuestType[] types)
    {
        var dailyChapterTable = DatabaseDefine.Master.EntityMEventQuestDailyGroupTargetChapterTable;
        var chapterTable = DatabaseDefine.Master.EntityMEventQuestChapterTable;
        var seqGroupTable = DatabaseDefine.Master.EntityMEventQuestSequenceGroupTable;

        var result = new List<EventQuestChapterData>();
        foreach (var chapter in chapterTable.All)
        {
            if (!types.Contains(chapter.EventQuestType))
                continue;

            // HINT: Filter out daily event chapters, as they are to be generated by CalculatorEventQuest.GenerateEventLimitDailyQuestData
            if (dailyChapterTable.All.Any(x => x.EventQuestChapterId == chapter.EventQuestChapterId))
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

    // CUSTOM: Get event quest chapters by ID
    public static EventQuestChapterData GetEventQuestChapter(int eventQuestChapterId)
    {
        var chapterTable = DatabaseDefine.Master.EntityMEventQuestChapterTable;
        var seqGroupTable = DatabaseDefine.Master.EntityMEventQuestSequenceGroupTable;

        var chapter = chapterTable.FindByEventQuestChapterId(eventQuestChapterId);
        if (chapter == null)
            return null;

        return new EventQuestChapterData
        {
            EventQuestChapterId = chapter.EventQuestChapterId,
            EventQuestType = chapter.EventQuestType,
            EventQuestName = GetEventQuestChapterName(chapter.NameEventQuestTextId, chapter.EventQuestType),
            EventQuestChapterDifficultyTypes = seqGroupTable.All.Where(x => x.EventQuestSequenceGroupId == chapter.EventQuestSequenceGroupId).Select(x => x.DifficultyType).ToList(),

            StartDatetime = chapter.StartDatetime,
            EndDatetime = chapter.EndDatetime
        };
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

        var userRouteTable = DatabaseDefine.User.EntityIUserMainQuestSeasonRouteTable;
        var userRoute = userRouteTable.FindByUserIdAndMainQuestSeasonId((CalculatorStateUser.GetUserId(), seasonId));

        var route = userRoute == null ?
            routeTable.All.FirstOrDefault(x => x.MainQuestSeasonId == seasonId) :
            routeTable.FindByMainQuestRouteId(userRoute.MainQuestRouteId);
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

    // CUSTOM: Get Guerrilla Quests for current day
    public static List<EventQuestData> GetTodayGuerrillaQuestData()
    {
        var result = new List<EventQuestData>();

        var guerrillaQuests = GenerateEventQuestData(CalculatorGuerrillaQuest.GetGuerrillaEventChapterId(), DifficultyType.NORMAL);
        foreach (var guerrillaQuest in guerrillaQuests)
        {
            var terms = GetCurrentQuestTodayTimeTable(guerrillaQuest.Quest.QuestId);
            if (!terms.Any())
                continue;

            var eventQuest = CreateEventQuestData(CalculatorStateUser.GetUserId(), guerrillaQuest.Quest, null, out _);
            result.Add(eventQuest);
        }

        return result;
    }

    // CUSTOM: Get Daily Quests for current day
    public static List<EventQuestData> GetTodayDailyQuestData()
    {
        var result = new List<EventQuestData>();

        foreach (var dailyChapter in GetEventQuestChapters(EventQuestType.DAY_OF_THE_WEEK))
        {
            var dailyQuests = GenerateEventQuestData(dailyChapter.EventQuestChapterId, dailyChapter.EventQuestChapterDifficultyTypes[0]);
            foreach (var dailyQuest in dailyQuests)
            {
                var terms = GetCurrentQuestTodayTimeTable(dailyQuest.Quest.QuestId);
                if (!terms.Any())
                    continue;

                if (result.Any(x => x.Quest.QuestId == dailyQuest.Quest.QuestId))
                    continue;

                var eventQuest = CreateEventQuestData(CalculatorStateUser.GetUserId(), dailyQuest.Quest, null, out _);
                result.Add(eventQuest);
            }
        }

        return result;
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
            IsClear = IsClearQuest(quest.QuestId, CalculatorStateUser.GetUserId()),
            DifficultyType = sequenceGroup.DifficultyType,
            Attribute = GetFirstQuestDisplayAttributeType(quest.QuestDisplayAttributeGroupId)
            //UnlockQuestText = GetQuestUnlockText(quest.QuestReleaseConditionListId),
            //QuestLevelText =
        };
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

        var eventQuestData = CreateEventQuestData(userId, eventQuest, null, out _);

        // CUSTOM: Check term here, to determine further availability
        eventQuestData.IsAvailable &= CalculatorDateTime.IsWithinThePeriod(eventQuestChapter.StartDatetime, eventQuestChapter.EndDatetime);

        return eventQuestData;
    }

    // CUSTOM: Checks if quest is locked by Quest ID
    public static bool IsQuestLocked(int questId)
    {
        var table = DatabaseDefine.Master.EntityMQuestTable;
        var masterQuest = table.FindByQuestId(questId);

        return IsQuestLocked(masterQuest, CalculatorStateUser.GetUserId(), out _, out _);
    }

    // CUSTOM: Checks if a quest is locked by quest information
    private static bool IsQuestLocked(EntityMQuest quest, long userId, out bool isClear, out bool isAvailable)
    {
        var dailyCount = quest.DailyClearableCount;

        var isUnlocked = IsUnlockedQuest(quest.QuestReleaseConditionListId, userId);
        var canPlay = CanPlayQuestCheckCount(userId, quest.QuestId, dailyCount);

        isClear = IsClearQuest(quest.QuestId, userId);
        isAvailable = !isClear || !quest.IsNotShowAfterClear;
        isAvailable &= IsWithinQuestTerm(quest.QuestId);

        return !isAvailable || !isUnlocked || !canPlay;
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

    public static string QuestName(int questId)
    {
        var masterQuest = DatabaseDefine.Master.EntityMQuestTable.FindByQuestId(questId);
        return GetQuestName(masterQuest.NameQuestTextId);
    }

    // CUSTOM: Get access to all mission data by quest ID
    public static QuestMissionData[] GetMissionData(int questId)
    {
        var table = DatabaseDefine.Master.EntityMQuestTable;
        var masterQuest = table.FindByQuestId(questId);

        return GetMissionData(questId, masterQuest.QuestMissionGroupId, CalculatorStateUser.GetUserId());
    }

    // CUSTOM: Get access to master data for a mission
    public static EntityMQuestMission GetEntityMQuestMission(int missionId)
    {
        var table = DatabaseDefine.Master.EntityMQuestMissionTable;
        return table.FindByQuestMissionId(missionId);
    }

    public static QuestMissionData GenerateQuestMissionData(int questId, int questMissionId, long userId)
    {
        var masterMission = DatabaseDefine.Master.EntityMQuestMissionTable.FindByQuestMissionId(questMissionId);
        var condValues = GenerateQuestMissionConditionValues(masterMission.QuestMissionConditionValueGroupId);

        return new QuestMissionData
        {
            MissionId = masterMission.QuestMissionId,
            MissionTitle = GenerateMissionText(masterMission.QuestMissionConditionType, masterMission.ConditionValue, condValues),
            IsClear = IsMissionClear(questId, masterMission.QuestMissionId, userId),
            QuestMissionConditionType = masterMission.QuestMissionConditionType
        };
    }

    public static bool IsMissionClear(int questId, int questMissionId, long userId)
    {
        if (!DatabaseDefine.User.EntityIUserQuestMissionTable.TryFindByUserIdAndQuestIdAndQuestMissionId((userId, questId, questMissionId), out var result))
            return false;

        return result.IsClear;
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

    #endregion Custom
}
