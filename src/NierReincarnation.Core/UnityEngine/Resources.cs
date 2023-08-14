using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.AssetStudio;
using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.UnityEngine;

public static class Resources
{
    private static readonly AssetsManager AssetManager = new();

    public static TextAsset LoadText(string fileName)
    {
        var fullPath = GetFileName(fileName);
        if (string.IsNullOrEmpty(fullPath))
        {
            return TextAsset.Empty;
        }

        AssetManager.LoadFiles(fullPath);

        var textAsset = AssetManager.TextAssets.FirstOrDefault();
        AssetManager.Clear();
        return textAsset ?? TextAsset.Empty;
    }

    public static List<TextAsset> LoadTexts(string path)
    {
        if (Directory.Exists(path))
        {
            AssetManager.LoadFolder(path);

            var textAssets = AssetManager.TextAssets.ToList();
            AssetManager.Clear();
            return textAssets;
        }

        return new List<TextAsset>();
    }

    private static string GetFileName(string fileName)
    {
        var fullPath = Path.Combine(Application.ApkPath, fileName);
        if (File.Exists(fullPath)) return fullPath;

        fullPath = Path.Combine(FileUtil.GetCachePath(), "v1", $"{DarkOctoSetupper.CreateSetting().AppId}", fileName);
        if (File.Exists(fullPath)) return fullPath;

        return string.Empty;
    }
}
