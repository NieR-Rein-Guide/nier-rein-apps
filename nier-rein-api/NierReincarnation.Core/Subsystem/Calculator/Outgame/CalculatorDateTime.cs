using System;
using TimeZoneConverter;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame
{
    public static class CalculatorDateTime
    {
        // CUSTOM: PST Timezone
        private static readonly TimeZoneInfo PstTimezone = TZConvert.GetTimeZoneInfo("Pacific Standard Time");

        public static bool IsAfterTodaySpanningTime(DateTimeOffset checkDateTime)
        {
            // CUSTOM: Logic to check if checkDateTime is after start of current day
            var startOfDay = TimeZoneInfo.ConvertTime(DateTime.Now, PstTimezone).Date;
            var pstCheckDateTime = TimeZoneInfo.ConvertTime(checkDateTime.DateTime, PstTimezone);

            return pstCheckDateTime >= startOfDay;
        }

        public static bool IsWithinThePeriod(long startUnixTime, long endUnixTime)
        {
            var now = UnixTimeNow();
            return IsWithinThePeriod(startUnixTime, endUnixTime, now);
        }

        public static bool IsWithinThePeriod(long startDateTime, long endDateTime, long currentDateTime)
        {
            return startDateTime < currentDateTime && currentDateTime < endDateTime;
        }

        public static long UnixTimeNow()
        {
            // CUSTOM: Implement unix epoch time
            return DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        // CUSTOM: Parse unix time to type-safe UTC
        public static DateTimeOffset FromUnixTime(long unixTime)
        {
            return TimeZoneInfo.ConvertTime(DateTimeOffset.FromUnixTimeMilliseconds(unixTime), TimeZoneInfo.Local);
        }

        //public static bool IsAfterTodaySpanningTime(DateTimeOffset checkDateTime)
        //{
        //    // CUSTOM: Logic to check if checkDateTime is after start of current day
        //    var startOfDay = FromUnixTime(UnixTimeNow());
        //    return checkDateTime >= startOfDay.Date;
        //}
    }
}
