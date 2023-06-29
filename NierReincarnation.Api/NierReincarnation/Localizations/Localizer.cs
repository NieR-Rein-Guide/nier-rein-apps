using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Octo.Util;
using NierReincarnation.Core.UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NierReincarnation.Localizations
{
    internal static class Localizer
    {
        private static readonly string[] Exclusions =
        {
            "credit.asset",
            "pb_text_garbled.asset"
        };

        public static IDictionary<string, string> Create(Language lang = Language.English)
        {
            var result = new Dictionary<string, string>();

            var rootPath = Path.Combine(FileUtil.GetCachePath(), "v1", $"{DarkOctoSetupper.CreateSetting().AppId}");
            var locPath = Path.Combine(rootPath, "assets", "text", GetLanguagePath(lang));

            if (!Directory.Exists(locPath)) return result;

            foreach (var locFile in Directory.EnumerateFiles(locPath, "*", SearchOption.AllDirectories))
            {
                // Exclude certain files, since they don't contain localizations
                if (Exclusions.Any(x => x == Path.GetFileName(locFile)))
                    continue;

                var locContent = Resources.LoadText(Path.GetRelativePath(rootPath, locFile));
                foreach (var line in locContent.Text.Replace(Environment.NewLine, "\n").Split('\n'))
                {
                    if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                        continue;

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

        private static string GetLanguagePath(Language lang) => lang switch
        {
            Language.English => "en",
            Language.Japanese => "ja",
            _ => "ko"
        };
    }
}
