using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Localization;

public static class LocalizationExtensions
{
    public static IDictionary<string, string> Localizations;

    public static string Localize(this string key)
    {
        if (Localizations == null)
            return string.Empty;

        if (!Localizations.ContainsKey(key))
            return string.Empty;

        return Localizations[key];
    }

    public static string LocalizeWithParams(this string key, params object?[] args)
    {
        return string.Format(Localize(key), args);
    }
}
