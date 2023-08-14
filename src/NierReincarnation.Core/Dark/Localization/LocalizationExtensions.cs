namespace NierReincarnation.Core.Dark.Localization;

public static class LocalizationExtensions
{
    public static IDictionary<string, string> Localizations;

    public static string Localize(this string key)
    {
        return (Localizations?.ContainsKey(key)) == true ? Localizations[key] : string.Empty;
    }

    public static string LocalizeWithParams(this string key, params object?[] args)
    {
        return string.Format(Localize(key), args);
    }
}
