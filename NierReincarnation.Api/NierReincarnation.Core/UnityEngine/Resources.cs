using AssetStudio;
using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.UnityEngine;

public static class Resources
{
    private static readonly AssetsManager Manager = new AssetsManager();

    // CUSTOM: Implements custom logic for the UnityEngine.LoadText method
    public static TextAsset LoadText(string fileName)
    {
        var fullPath = GetFileName(fileName);
        if (fullPath == null)
        {
            // Log error with message ('The asset {0} was not found.', fullPath)
            return TextAsset.Empty;
        }

        Manager.LoadFiles(fullPath);

        var texts = Manager.assetsFileList.SelectMany(af => af.Objects.Where(o => o is AssetStudio.TextAsset).Select(o => (o as AssetStudio.TextAsset)?.m_Script)).ToArray();
        var firstText = texts.FirstOrDefault(x => x != null);

        Manager.Clear();

        if (firstText == null)
            return TextAsset.Empty;

        return new TextAsset(firstText);
    }

    public static ImageAsset LoadImage(string fileName)
    {
        var fullPath = GetFileName(fileName);
        if (fullPath == null)
        {
            // Log error with message ('The asset {0} was not found.', fullPath)
            return ImageAsset.Empty;
        }

        Manager.LoadFiles(fullPath);

        var texture = Manager.assetsFileList.SelectMany(x => x.Objects.Where(o => o is Sprite).Select(o => (o as Sprite).GetImage())).ToArray();
        var firstTexture = texture.FirstOrDefault(x => x != null);

        //var texture = Manager.assetsFileList.SelectMany(x => x.Objects.Where(o => o is Texture2D).Select(o => new Texture2DConverter(o as Texture2D).DecodeTexture2D())).ToArray();
        //var firstTexture = texture.FirstOrDefault(x => x != null);

        Manager.Clear();

        if (firstTexture == null)
            return ImageAsset.Empty;

        return new ImageAsset(firstTexture);
    }

    private static string GetFileName(string fileName)
    {
        var fullPath = Path.Combine(Application.ApkPath, fileName);
        if (File.Exists(fullPath))
            return fullPath;

        fullPath = Path.Combine(FileUtil.GetCachePath(), "v1", $"{DarkOctoSetupper.CreateSetting().AppId}", fileName);
        if (File.Exists(fullPath))
            return fullPath;

        return null;
    }
}
