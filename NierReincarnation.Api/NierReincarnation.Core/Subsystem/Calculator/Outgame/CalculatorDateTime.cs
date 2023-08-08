using NierReincarnation.Core.Custom;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using System;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame
{
    public static class CalculatorDateTime
    {
        // CUSTOM: PST Timezone
        internal static readonly TimeZoneInfo KstTimezone = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
        internal static readonly TimeZoneInfo PstTimezone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        internal static readonly TimeZoneInfo LocalTimezone = TimeZoneInfo.Local;
        private const int KstDailyResetHour_ = 17;

        public static int kUnixTimeSecond = 1000; // 0x0

        private const long kSecondsToMillisecondsOffset = 1000; // 0x10
        private const int TimeDifferenceYear = 365; // 0x18
        private const int MinDays = 0; // 0x1C
        public static readonly int DayHours = 24; // 0x20
        private const int MinHours = 0; // 0x24
        private const int LimitMinutes = 59; // 0x28
        private const int MinMinutes = 0; // 0x2C
        private const int MaxSeconds = 59; // 0x30
        private const int MinSeconds = 0; // 0x34
        private const double kBorderMilliseconds = 1; // 0x38

        public static string DateTimeFormatTimeTable => "HH:mm";

        public static string DateTimeFormatEvent => "MM/dd HH:mm";

        public static string DateTimeFormatBigHunt => "yyyy/MM/dd";

        public static string DateTimeFormatGacha => "yyyy/MM/dd HH\\:mm";

        public static string SpanTimeFormatTimeTableSecond => "hh\\:mm\\:ss";

        private static string SpanTimeFormatTimeTable => "hh\\:mm";

        public static string ConvertYearMonthDateTimeToString(DateTime dateTime) => dateTime.ToString(UserInterfaceTextKey.Date.kYearMonthDateTime.Localize());

        public static string ConvertYearMonthDateTimeToString(DateTimeOffset dateTimeOffset) => ConvertYearMonthDateTimeToString(dateTimeOffset.DateTime);

        public static string ConvertYearMonthDateToString(DateTime dateTime) => dateTime.ToString(UserInterfaceTextKey.Date.kYearMonthDate.Localize());

        public static string ConvertYearMonthDateToString(DateTimeOffset dateTimeOffset) => ConvertYearMonthDateToString(dateTimeOffset.DateTime);

        public static string GetPassedTimeString(long unixTime)
        {
            throw new NotImplementedException();
        }

        public static string GetRemainTimeTableString(DateTimeOffset dateTime)
        {
            throw new NotImplementedException();
        }

        public static TimeSpan GetRemainTime(in DateTimeOffset dateTime)
        {
            throw new NotImplementedException();
        }

        public static string GetRemainTimeHmString(in DateTimeOffset dateTime)
        {
            throw new NotImplementedException();
        }

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

        public static string GetRemainTimeString(in DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public static string GetRemainDigitalTimeString(in DateTimeOffset dateTime)
        {
            TimeSpan remainingTime = dateTime - Now();

            return remainingTime.TotalDays >= MinDays
                ? GetRemainTimeString((int)remainingTime.TotalDays)
                : GetRemainDigitalTimeString((int)remainingTime.TotalHours, remainingTime.Minutes, remainingTime.Seconds);
        }

        public static string GetRemainTimeZero() => GetRemainTimeRoundUpString(MinHours, MinMinutes, MinSeconds);

        private static string GetRemainTimeString(int days) => UserInterfaceTextKey.Common.kTimeDay.LocalizeWithParams(days);

        private static string GetRemainTimeRoundUpString(int hours, int minutes, int seconds)
        {
            var hsTimeRoundUpSeconds = GetHsTimeRoundUpSeconds(hours, minutes, seconds);

            return GetRemainTimeString(hsTimeRoundUpSeconds.Item1, hsTimeRoundUpSeconds.Item2);
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

        private static string GetRemainTimeString(int hours, int minutes) => UserInterfaceTextKey.Common.kTime.LocalizeWithParams(hours, minutes);

        private static string GetRemainTimeStringWithoutZero(int hours, int minutes)
        {
            var result = string.Empty;

            if (MinHours < hours)
                result += UserInterfaceTextKey.Common.kTimeHour.LocalizeWithParams(hours);

            if (MinMinutes < minutes)
                result += UserInterfaceTextKey.Common.kTimeMinute.LocalizeWithParams(minutes);

            return result;
        }

        private static string GetRemainDigitalTimeString(int hours, int minutes, int seconds)
        {
            int roundedMinutes = MinSeconds < seconds ? minutes + 1 : minutes;
            int roundedHours = hours;

            if (roundedMinutes > LimitMinutes)
            {
                roundedMinutes = MinMinutes;
                roundedHours++;
            }

            return UserInterfaceTextKey.Common.kTimeDigital.LocalizeWithParams(roundedHours, roundedMinutes);
        }

        public static bool IsValid(long unixTime)
        {
            return unixTime < 2051190000000;
        }

        public static bool IsValid(DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToUnixTimeMilliseconds() < 2051190000000;
        }

        public static bool IsWithinThePeriod(long startUnixTime, long endUnixTime) => IsWithinThePeriod(startUnixTime, endUnixTime, UnixTimeNow());

        public static bool IsWithinThePeriod(long startDateTime, long endDateTime, long currentDateTime)
        {
            return startDateTime < currentDateTime && currentDateTime < endDateTime;
        }

        public static bool IsPassed(long unixTime) => UnixTimeNow() > unixTime;

        public static bool IsSameDay(long unixTime)
        {
            var inputBase = UnixTimeToBaseTime(unixTime);
            var nowBase = UnixTimeToBaseTime(UnixTimeNow());

            return inputBase.Day == nowBase.Day && inputBase.Month == nowBase.Month && inputBase.Year == nowBase.Year;
        }

        public static bool IsAfterTodaySpanningTime(long checkDateTime)
        {
            // CUSTOM: Logic to check if checkDateTime is after start of current day (17:00 KST)
            var kstCheckDateTime = ToKst(FromUnixTime(checkDateTime));
            var nextResetDateTime = kstCheckDateTime.Hour < KstDailyResetHour_ ?
                kstCheckDateTime.Date + TimeSpan.FromHours(KstDailyResetHour_) :
                kstCheckDateTime.Date + TimeSpan.FromHours(DayHours + KstDailyResetHour_);

            return KstNow() < AsKst(nextResetDateTime);
        }

        public static long UnixTimeNow()
        {
            // CUSTOM: Implement unix epoch time
            return ToUnixTime(Now());
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

        #endregion Local methods

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

        #endregion KST methods

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

        #endregion PST methods

        #region Support

        // CUSTOM: Sets timezone without conversion
        internal static DateTimeOffset ChangeTimezone(DateTime dateTime, TimeZoneInfo targetTimezone)
        {
            return new DateTimeOffset(dateTime, targetTimezone.BaseUtcOffset);
        }

        #endregion Support
    }
}
