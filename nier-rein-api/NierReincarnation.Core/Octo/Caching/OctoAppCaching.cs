using System;
using System.Collections.Generic;
using System.IO;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.Octo.Caching
{
    class OctoAppCaching // TypeDefIndex: 6574
    {
        // Fields
        private static readonly string Tag = "OctoAppCaching"; // 0x0
        private static readonly string OctoDir = "Octo"; // 0x8
        private static readonly string ListFileName = "l"; // 0x10

        private readonly Dictionary<string, EmbeddedInfo> _embeddedDictionary; // 0x10
        private readonly string _rootDir; // 0x18

        public OctoAppCaching()
        {
            _rootDir = OctoDir;

            var listFile = FileUtil.UnsafePathCombine(OctoDir, ListFileName);
            using var reader = new StreamReader(listFile);

            var listContent = reader.ReadToEnd();
            if (listContent == "")
            {
                // TODO: Unknown logic
            }

            _embeddedDictionary = new Dictionary<string, EmbeddedInfo>();
        }

        public static string GetRootDir()
        {
            return OctoDir;
        }

        public static bool HasInAppCache()
        {
            return File.Exists(FileUtil.UnsafePathCombine(OctoDir, ListFileName));
        }

        public bool IsInApp(string bucket, ulong generation, MD5Value md5)
        {
            if (!_embeddedDictionary.TryGetValue(bucket, out var value))
                return false;

            if (value.generation < generation)
                return value.md5.Equals(md5);

            return true;
        }

        public string GetFilePath(string bucket, Item item)
        {
            throw new NotImplementedException();
        }

        struct EmbeddedInfo // TypeDefIndex: 6575
        {
            // Fields
            public ulong generation; // 0x0
            public MD5Value md5; // 0x8
        }
    }
}
