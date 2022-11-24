using System;
using NierReincarnation.Core.UnityEngine;
using NodaTime;

namespace NierReincarnation.Core.Dark.Localization
{
    public static class LocalizeTime
    {
        private static readonly string kTokyoTimeZoneId = "Asia/Tokyo"; // 0x0
        private static readonly string kPasificStandardTimeZoneId = "Etc/GMT+8"; // 0x8

        private static readonly string kLocalizeSettingPath = "settings/localize_time/{0}/localize_time_settings"; // 0x28
        private static LocalizeTimeSettings _settings; // 0x30

        private static readonly string kWorldwidePath = "ww"; // 0x40
        private static DateTimeZone _baseTimeZone; // 0x48

        public static DateTimeZone BaseTimeZone => _baseTimeZone ??= DateTimeZoneProviders.Tzdb.GetZoneOrNull(GetTimeZoneId(_settings.TargetTimeZone));

        public static void Initialize()
        {
            //var path = string.Format(kLocalizeSettingPath, kWorldwidePath);
            //_settings = Resources.LoadObject<LocalizeTimeSettings>(path);

            _settings = new LocalizeTimeSettings { TargetTimeZone = TimeZoneType.PacificStandardTime };
        }

        public static DateTimeOffset GetUnixTime(long unixTime)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(unixTime);
        }

        public static DateTimeOffset GetBaseTimeZoneTime(long unixTime)
        {
            return GetUnixTime(unixTime).ConvertBaseTimeZone();
        }

        public static DateTimeOffset ConvertBaseTimeZone(this DateTimeOffset dto)
        {
            var secs = dto.ToUnixTimeSeconds();
            var unix = Instant.FromUnixTimeSeconds(secs);

            var zoned = new ZonedDateTime(unix, BaseTimeZone);
            return zoned.ToDateTimeOffset();
        }

        public static string GetTimeZoneId(TimeZoneType targetTimeZone)
        {
            switch (targetTimeZone)
            {
                case TimeZoneType.PacificStandardTime:
                    return kPasificStandardTimeZoneId;

                case TimeZoneType.Tokyo:
                    return kTokyoTimeZoneId;

                default:
                    // LogError for not finding timezone ID
                    return TimeZoneInfo.Local.Id;
            }
        }
    }
}
