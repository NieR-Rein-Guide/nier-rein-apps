using System;
using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorGuerrillaQuest
    {
        public static readonly int kDefaultFreeOpenRemainCount = 0; // 0x0
        private static readonly int kDefaultFreeOpenMaxCount = 1; // 0x4
        private static readonly int kDefaultGuerrillaFreeOpenOpeningTimeMinutes = 60; // 0x8

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
            return guerillaChapter.First().EventQuestChapterId;
        }

        private static bool TryGetGuerrillaFreeOpen(out EntityMEventQuestGuerrillaFreeOpen resultGuerrillaFreeOpenEntity)
        {
            var table = DatabaseDefine.Master.EntityMEventQuestGuerrillaFreeOpenTable;
            resultGuerrillaFreeOpenEntity = table.All.FirstOrDefault(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime));

            return resultGuerrillaFreeOpenEntity != null;
        }

        private static bool TryGetUserGuerrillaFreeOpen(long userId, out EntityIUserEventQuestGuerrillaFreeOpen guerrillaFreeOpen)
        {
            var table = DatabaseDefine.User.EntityIUserEventQuestGuerrillaFreeOpenTable;
            guerrillaFreeOpen = table.FindByUserId(userId);
            if (guerrillaFreeOpen == null)
                return false;

            return CalculatorDateTime.IsAfterTodaySpanningTime(guerrillaFreeOpen.StartDatetime);
        }
    }
}
