﻿namespace NierReincarnation.Core.Dark.Localization;

public static class LocalizeTime
{
    private const string kTokyoTimeZoneId = "Asia/Tokyo";
    private const string kPasificStandardTimeZoneId = "Etc/GMT+8";

    private const string kLocalizeSettingPath = "settings/localize_time/{0}/localize_time_settings";
    private static LocalizeTimeSettings _settings;

    private const string kWorldwidePath = "ww";
    private static TimeZoneInfo _baseTimeZone;

    public static TimeZoneInfo BaseTimeZone => _baseTimeZone ??= TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneId(_settings.TargetTimeZone));

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
        return TimeZoneInfo.ConvertTime(dto, BaseTimeZone);
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
                return TimeZoneInfo.Local.Id;
        }
    }
}
