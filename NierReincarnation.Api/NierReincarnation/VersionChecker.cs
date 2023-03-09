using NierReincarnation.Core.UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace NierReincarnation
{
    public static class VersionChecker
    {
        private const string ApkMirror = "https://www.apkmirror.com/uploads/?appcategory=nier-reincarnation";

        private static readonly Regex ListHeader = new(@"<h5 title=""NieR Re\[in\]carnation (\d+\.\d+\.\d+)");

        public static bool CanDetermine(Language language)
        {
            return language == Language.English;
        }

        public static string GetCurrentVersion(Language language)
        {
            if (language != Language.English)
                throw new InvalidOperationException("Current version can only be determined for the global release.");

            // Get content
            var req = WebRequest.CreateHttp(ApkMirror);
            var res = req.GetResponse().GetResponseStream();
            if (res == null)
                return string.Empty;

            var reader = new StreamReader(res);
            var content = reader.ReadToEnd();

            // Get list content
            var match = ListHeader.Matches(content).FirstOrDefault();
            if (match == null)
                return string.Empty;

            return match.Groups[1].Value;
        }
    }
}
