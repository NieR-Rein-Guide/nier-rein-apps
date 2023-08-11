using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorEventQuest
{
    public static EventQuestType GetEventQuestTypeByChapterId(int chapterId)
    {
        var chapterTable = DatabaseDefine.Master.EntityMEventQuestChapterTable;
        var chapter = chapterTable.FindByEventQuestChapterId(chapterId);
        if (chapter == null)
            return EventQuestType.UNKNOWN;

        return chapter.EventQuestType;
    }

    // CUSTOM: Checks if daily group reward was already received
    public static bool IsLimitDailyGroupRewardReceived()
    {
        var userId = CalculatorStateUser.GetUserId();
        if (!DatabaseDefine.User.EntityIUserEventQuestDailyGroupCompleteRewardTable.TryFindByUserId(userId, out var element))
            return false;

        return CalculatorDateTime.IsSameDay(element.LastRewardReceiveDatetime);
    }

    public static LimitDailyQuestGroupData GenerateEventLimitDailyQuestData()
    {
        var userId = CalculatorStateUser.GetUserId();
        var (chapterId, questId) = CalculatorPortalCage.GetDailyQuestChapterIdAndQuestId(Config.GetPortalCageSceneId(), CalculatorPortalCage.kDailyQuestAccessPointIndex);

        var chapterQuests = CalculatorQuest.CreateEventQuestListInEndTerm(chapterId);

        LimitDailyQuestData limitQuest = null;
        if (CalculatorQuest.IsValidEventQuestChapterTerm(chapterId) && CalculatorQuest.IsValidEventQuestTerm(questId) && CalculatorQuest.IsUnlockedQuestByQuestId(questId, userId))
            limitQuest = CalculatorQuest.CreateLimitDailyQuestData(userId, chapterQuests.FirstOrDefault(x => x.QuestId == questId));

        var list = new List<LimitDailyQuestData> { limitQuest };

        var getGroup = TryGetEventQuestDailyGroupWithinPeriod(out var dailyGroup);
        if (!getGroup)
            return new LimitDailyQuestGroupData { Quests = list };

        var table = DatabaseDefine.Master.EntityMEventQuestDailyGroupTargetChapterTable;
        foreach (var groupChapter in table.All.Where(x => x.EventQuestDailyGroupTargetChapterId == dailyGroup.EventQuestDailyGroupTargetChapterId).OrderBy(x => x.SortOrder))
        {
            var quest = CalculatorQuest.GetLimitDailyChapterQuest(groupChapter.EventQuestChapterId);
            limitQuest = CalculatorQuest.CreateLimitDailyQuestData(CalculatorStateUser.GetUserId(), quest);

            list.Add(limitQuest);
        }
        list.RemoveAll(x => x == null);

        return new LimitDailyQuestGroupData
        {
            EventQuestDailyGroupId = dailyGroup.EventQuestDailyGroupId,
            IsQuestAllClear = list.All(x => x.IsDailyQuestCleared),

            CreatedDataUnixTime = CalculatorDateTime.UnixTimeNow(),
            EndUnixTime = dailyGroup.EndDatetime,

            Quests = list,
            CompleteRewards = DatabaseDefine.Master.EntityMEventQuestDailyGroupCompleteRewardTable.All
                .Where(x => x.EventQuestDailyGroupCompleteRewardId == dailyGroup.EventQuestDailyGroupCompleteRewardId)
                .Select(x => new DataPossessionItem
                {
                    PossessionId = x.PossessionId,
                    PossessionType = (PossessionType)x.PossessionType,
                    Count = x.Count
                }).ToList()
        };
    }

    public static bool TryGetEventQuestDailyGroupWithinPeriod(out EntityMEventQuestDailyGroup entityDailyGroup)
    {
        var table = DatabaseDefine.Master.EntityMEventQuestDailyGroupTable;
        var periodGroups = table.All.Where(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime));

        entityDailyGroup = periodGroups.FirstOrDefault();
        return entityDailyGroup != null;
    }
}
