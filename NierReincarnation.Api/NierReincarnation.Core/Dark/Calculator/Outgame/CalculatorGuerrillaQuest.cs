using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorGuerrillaQuest
{
    public static readonly int kDefaultFreeOpenRemainCount;
    private const int kDefaultFreeOpenMaxCount = 1;
    private const int kDefaultGuerrillaFreeOpenOpeningTimeMinutes = 60;

    // TODO: Implement
    public static bool IsValidGuerrillaQuestTerm(int eventQuestId, long userId)
    {
        throw new NotImplementedException();
        //if (!TryGetQuestMaxEndTime(eventQuestId, 0, out var maxEndTime) &&
        //    !IsQuestWithinTermByGuerrillaFreeOpenScheduleCorrespondence(eventQuestId) ||
        //    !IsTermGuerrillaFreeOpenByQuestId(eventQuestId, userId))
        //    return false;

        //return true;
    }

    public static int GetFreeOpenRemainCount(long userId)
    {
        if (!TryGetGuerrillaFreeOpen(out var freeOpen))
            return kDefaultFreeOpenRemainCount;

        if (!TryGetUserGuerrillaFreeOpen(userId, out var userFreeOpen))
            return freeOpen.DailyOpenMaxCount;

        return freeOpen.DailyOpenMaxCount - userFreeOpen.DailyOpenedCount;
    }

    public static int GetFreeOpenMaxCount()
    {
        if (!TryGetGuerrillaFreeOpen(out var freeOpen))
            return kDefaultFreeOpenMaxCount;

        return freeOpen.DailyOpenMaxCount;
    }

    public static string GetGuerrillaFreeOpenOpeningTime()
    {
        if (!TryGetGuerrillaFreeOpen(out var freeOpen))
            return UserInterfaceTextKey.Common.kTimeMinute.LocalizeWithParams(kDefaultGuerrillaFreeOpenOpeningTimeMinutes);

        var openMinutes = freeOpen.OpenMinutes;
        var spanMinutes = TimeSpan.FromMinutes(openMinutes);

        return CalculatorDateTime.GetRemainTimeHmStringWithoutZero(spanMinutes);
    }

    public static string GetGuerrillaQuestTimeTableText(int eventQuestChapterId)
    {
        var result = string.Empty;

        var terms = CalculatorQuest.GetCurrentEventChapterTodayTimeTable(eventQuestChapterId);
        for (var i = 0; i < terms.Count; i++)
        {
            var term = terms[i];
            var timeTableFormat = CalculatorDateTime.DateTimeFormatTimeTable;

            var formattedStartTime = CalculatorDateTime.ToLocal(term.Start).ToString(timeTableFormat);
            var formattedEndTime = CalculatorDateTime.ToLocal(term.End).ToString(timeTableFormat);

            result += UserInterfaceTextKey.Quest.kEventQuestHoldTermTemplate.LocalizeWithParams(i + 1, formattedStartTime, formattedEndTime) + Environment.NewLine;
        }

        return result;
    }

    public static int GetGuerrillaEventChapterId()
    {
        var guerillaChapter = CalculatorQuest.GetEventQuestChapters(EventQuestType.GUERRILLA);
        return guerillaChapter[0].EventQuestChapterId;
    }

    private static bool TryGetGuerrillaFreeOpen(out EntityMEventQuestGuerrillaFreeOpen resultGuerrillaFreeOpenEntity)
    {
        resultGuerrillaFreeOpenEntity = DatabaseDefine.Master.EntityMEventQuestGuerrillaFreeOpenTable.All.FirstOrDefault(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime));

        return resultGuerrillaFreeOpenEntity != null;
    }

    private static bool TryGetUserGuerrillaFreeOpen(long userId, out EntityIUserEventQuestGuerrillaFreeOpen guerrillaFreeOpen)
    {
        return DatabaseDefine.User.EntityIUserEventQuestGuerrillaFreeOpenTable.TryFindByUserId(userId, out guerrillaFreeOpen)
            && CalculatorDateTime.IsAfterTodaySpanningTime(guerrillaFreeOpen.StartDatetime);
    }
}
