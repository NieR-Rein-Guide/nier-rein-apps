using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Octo.Util;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Localizations
{
    class Localizer
    {
        private static string[] _exclusions =
        {
            "credit.asset",
            "pb_text_garbled.asset"
        };

        public static IDictionary<string, string> Create()
        {
            var result = new Dictionary<string, string>();

            var rootPath = Path.Combine(FileUtil.GetCachePath(), "v1", $"{DarkOctoSetupper.CreateSetting().AppId}");
            var locPath = Path.Combine(rootPath, "assets", "text", "en");

            if (!Directory.Exists(locPath))
                return result;

            foreach (var locFile in Directory.EnumerateFiles(locPath, "*", SearchOption.AllDirectories))
            {
                // Exclude certain files, since they don't contain localizations
                if (_exclusions.Any(x => x == Path.GetFileName(locFile)))
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
                        // ignored
                    }
                }
            }

            return result;
        }
    }
}
