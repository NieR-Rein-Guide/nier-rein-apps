using NierReincarnation.Api.Localizations;
using NierReincarnation.Api.Service;
using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Octo.Util;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Localizations;

public class PhysicalTextLocalizer(bool skipExistingFiles = true) : BaseTextLocalizer
{
    public override async Task<Dictionary<string, string>> CreateAsync(SystemLanguage lang = SystemLanguage.English)
    {
        Dictionary<string, string> result = [];

        // Download assets on disk
        await AssetService.DownloadTextAssetsAsync(lang, skipExistingFiles);

        // Process assets
        var rootPath = Path.Combine(FileUtil.GetCachePath(), "v1", $"{DarkOctoSetupper.CreateSetting().AppId}");
        var locPath = Path.Combine(rootPath, "assets", "text", GetLanguagePath(lang));

        return ProcessAssets(Resources.LoadTexts(locPath));
    }

    private static string GetLanguagePath(SystemLanguage lang) => lang switch
    {
        SystemLanguage.English => "en",
        SystemLanguage.Japanese => "ja",
        _ => "ko"
    };
}
