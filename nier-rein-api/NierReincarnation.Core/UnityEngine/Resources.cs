using System.Diagnostics;
using System.IO;
using System.Linq;
using AssetStudio;
using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.UnityEngine
{
    static class Resources
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
}
