using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Octo.Util;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Localizations;

internal static class Localizer
{
    public static IDictionary<string, string> Create(SystemLanguage lang = SystemLanguage.English)
    {
        var result = new Dictionary<string, string>();

        var rootPath = Path.Combine(FileUtil.GetCachePath(), "v1", $"{DarkOctoSetupper.CreateSetting().AppId}");
        var locPath = Path.Combine(rootPath, "assets", "text", GetLanguagePath(lang));

        foreach (var textAsset in Resources.LoadTexts(locPath))
        {
            foreach (var line in textAsset.Text.Replace(Environment.NewLine, "\n").Split('\n'))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//")) continue;

                try
                {
                    var colonIndex = line.IndexOf(':');
                    result[line[..colonIndex]] = line[(colonIndex + 1)..];
                }
                catch (Exception)
                {
                    // Ignored
                }
            }
        }

        return result;
    }

    private static string GetLanguagePath(SystemLanguage lang) => lang switch
    {
        SystemLanguage.English => "en",
        SystemLanguage.Japanese => "ja",
        _ => "ko"
    };
}
