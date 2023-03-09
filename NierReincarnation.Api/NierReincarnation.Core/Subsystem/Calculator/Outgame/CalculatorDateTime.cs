using System;
using NierReincarnation.Core.Custom;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using TimeZoneConverter;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame
{
    public static class CalculatorDateTime
    {
        // CUSTOM: PST Timezone
        internal static readonly TimeZoneInfo KstTimezone = TZConvert.GetTimeZoneInfo("Korea Standard Time");
        internal static readonly TimeZoneInfo PstTimezone = TZConvert.GetTimeZoneInfo("Pacific Standard Time");
        internal static readonly TimeZoneInfo LocalTimezone = TimeZoneInfo.Local;
        private const int KstDailyResetHour_ = 17;

        public static int kUnixTimeSecond = 1000; // 0x0

        private static readonly int MinDays = 0; // 0x1C
        public static readonly int DayHours = 24; // 0x20
        private static readonly int MinHours = 0; // 0x24
        private static readonly int LimitMinutes = 59; // 0x28
        private static readonly int MinMinutes = 0; // 0x2C
        private static readonly int MinSeconds = 0; // 0x34
        private static readonly double kBorderMilliseconds = 1; // 0x38

        public static string DateTimeFormatTimeTable => "HH:mm";

        public static bool IsAfterTodaySpanningTime(long checkDateTime)
        {
            // CUSTOM: Logic to check if checkDateTime is after start of current day (17:00 KST)
            var kstCheckDateTime = ToKst(FromUnixTime(checkDateTime));
            var nextResetDateTime = kstCheckDateTime.Hour < KstDailyResetHour_ ?
                kstCheckDateTime.Date + TimeSpan.FromHours(KstDailyResetHour_) :
                kstCheckDateTime.Date + TimeSpan.FromHours(DayHours + KstDailyResetHour_);

            return KstNow() < AsKst(nextResetDateTime);
        }

        public static bool IsWithinThePeriod(long startUnixTime, long endUnixTime)
        {
            return IsWithinThePeriod(startUnixTime, endUnixTime, UnixTimeNow());
        }

        public static bool IsWithinThePeriod(long startDateTime, long endDateTime, long currentDateTime)
        {
            return startDateTime < currentDateTime && currentDateTime < endDateTime;
        }

        // CUSTOM: Checks if current time lies between two given DateTimeOffset structs
        public static bool IsWithinThePeriod(DateTimeOffset startUnixTime, DateTimeOffset endUnixTime)
        {
            return IsWithinThePeriod(startUnixTime, endUnixTime, Now());
        }

        // CUSTOM: Checks if current time lies between two given DateTimeOffset structs
        public static bool IsWithinThePeriod(DateTimeOffset startUnixTime, DateTimeOffset endUnixTime, DateTimeOffset currentDateTime)
        {
            return startUnixTime < currentDateTime && currentDateTime < endUnixTime;
        }

        public static bool IsSameDay(long unixTime)
        {
            var inputBase = UnixTimeToBaseTime(unixTime);
            var nowBase = UnixTimeToBaseTime(UnixTimeNow());

            return inputBase.Day == nowBase.Day && inputBase.Month == nowBase.Month && inputBase.Year == nowBase.Year;
        }

        public static long UnixTimeNow()
        {
            // CUSTOM: Implement unix epoch time
            return ToUnixTime(Now());
        }

        public static DateTime UnixTimeToBaseTime(long unixTime)
        {
            return LocalizeTime.GetBaseTimeZoneTime(unixTime).DateTime;
        }

        // CUSTOM: Parse unix time to type-safe UTC
        public static DateTimeOffset FromUnixTime(long unixTime)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(unixTime);
        }

        // CUSTOM: Parse type-safe UTC to unix time
        public static long ToUnixTime(DateTimeOffset dateTime)
        {
            return dateTime.ToUnixTimeMilliseconds();
        }

        public static bool IsFuzzyEqualDateTime(DateTime dateTime1, DateTime dateTime2)
        {
            var totalSecs = (dateTime1 - dateTime2).TotalSeconds;
            totalSecs = Math.Abs(totalSecs);

            return totalSecs < kBorderMilliseconds;
        }

        internal static DateTimeOffset GetTodayChangeDateTime()
        {
            // CUSTOM: Redirected to DateTimeConversions, since those date times are used in CRON related methods
            return DateTimeConversions.GetTodayChangeDateTime();
        }

        internal static DateTimeOffset GetNextChangeDateTime()
        {
            return GetTodayChangeDateTime().AddDays(1);
        }

        #region String conversions

        public static string GetRemainTimeHmStringWithoutZero(in TimeSpan timeSpan)
        {
            var hours = timeSpan.Hours;
            var days = timeSpan.Days;
            if (MinDays < days)
                hours += DayHours * days;

            var minutes = timeSpan.Minutes;
            var seconds = timeSpan.Seconds;
            var roundUp = GetHsTimeRoundUpSeconds(hours, minutes, seconds);
            return GetRemainTimeStringWithoutZero(roundUp.Item1, roundUp.Item2);
        }

        private static (int, int) GetHsTimeRoundUpSeconds(int hours, int minutes, int seconds)
        {
            if (MinSeconds < seconds)
                minutes++;

            if (LimitMinutes < minutes)
            {
                minutes = MinMinutes;
                hours++;
            }

            return (hours, minutes);
        }

        private static string GetRemainTimeStringWithoutZero(int hours, int minutes)
        {
            var result = string.Empty;

            if (MinHours < hours)
                result += UserInterfaceTextKey.Common.kTimeHour.LocalizeWithParams(hours);

            if (MinMinutes < minutes)
                result += UserInterfaceTextKey.Common.kTimeMinute.LocalizeWithParams(minutes);

            return result;
        }

        #endregion

        #region Local methods

        // CUSTOM: Gets the current date and time in the system timezone
        private static DateTimeOffset Now() => DateTimeOffset.Now;

        // CUSTOM: Converts the timezone of the given DateTimeOffset struct to the system timezone
        public static DateTimeOffset ToLocal(DateTimeOffset dateTime)
        {
            return TimeZoneInfo.ConvertTime(dateTime, LocalTimezone);
        }

        // CUSTOM: Sets the timezone of the given DateTime struct to the system timezone without conversion
        public static DateTimeOffset AsLocal(DateTime dateTime)
        {
            return ChangeTimezone(dateTime, LocalTimezone);
        }

        #endregion

        #region KST methods

        // CUSTOM: Gets the current date and time in KST timezone
        private static DateTimeOffset KstNow() => ToKst(Now());

        // CUSTOM: Converts the timezone of the given DateTimeOffset struct to KST
        private static DateTimeOffset ToKst(DateTimeOffset dateTime)
        {
            return TimeZoneInfo.ConvertTime(dateTime, KstTimezone);
        }

        // CUSTOM: Sets the timezone of the given DateTime struct to KST without conversion
        private static DateTimeOffset AsKst(DateTime dateTime)
        {
            return ChangeTimezone(dateTime, KstTimezone);
        }

        #endregion

        #region PST methods

        // CUSTOM: Gets the current date and time in KST timezone
        internal static DateTimeOffset PstNow() => ToPst(Now());

        // CUSTOM: Converts the timezone of the given DateTimeOffset struct to KST
        private static DateTimeOffset ToPst(DateTimeOffset dateTime)
        {
            return TimeZoneInfo.ConvertTime(dateTime, PstTimezone);
        }

        // CUSTOM: Sets the timezone of the given DateTime struct to KST without conversion
        internal static DateTimeOffset AsPst(DateTime dateTime)
        {
            return ChangeTimezone(dateTime, PstTimezone);
        }

        #endregion

        #region Support

        // CUSTOM: Sets timezone without conversion
        internal static DateTimeOffset ChangeTimezone(DateTime dateTime, TimeZoneInfo targetTimezone)
        {
            return new DateTimeOffset(dateTime, targetTimezone.BaseUtcOffset);
        }

        #endregion
    }
}
