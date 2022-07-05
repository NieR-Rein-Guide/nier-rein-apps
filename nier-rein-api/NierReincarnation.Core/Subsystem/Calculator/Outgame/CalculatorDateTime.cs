using System;
using Serilog;
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
            return startUnixTime < now && now < endUnixTime;
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
