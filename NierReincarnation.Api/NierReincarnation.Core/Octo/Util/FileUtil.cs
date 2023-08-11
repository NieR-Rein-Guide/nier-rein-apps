using System.IO;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Octo.Util
{
    static class FileUtil
    {
        private static readonly string Tag = "Octo/FileUtil";
        private static readonly string OctoDirectory = "octo";
        private static readonly string CacheDirectory = "Caches";
        private static string _mobileRootPath = null;

        public static string GetCachePath()
        {
            return GetMobileOctoRoot();
        }

        public static string GetDatabaseRoot()
        {
            return GetMobileOctoRoot();
        }

        public static void CreateDirectory(string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(dir) || Directory.Exists(dir))
                return;

            Directory.CreateDirectory(dir);
        }

        private static string GetMobileOctoRoot()
        {
            return _mobileRootPath ??= GetAndroidOctoRoot();
        }

        // CUSTOM: Implementation by observation of behaviour
        private static string GetAndroidOctoRoot()
        {
            var octoRoot = Path.Combine(Application.DataPath, "files", OctoDirectory);
            if (!Directory.Exists(octoRoot))
                Directory.CreateDirectory(octoRoot);

            return octoRoot;
        }

        public static byte[] ReadAllBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public static Error WriteAllBytes(string path, params byte[][] data)
        {
            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            foreach (var dat in data)
                fileStream.Write(dat);

            return null;
        }

        public static bool FileDelete(string filePath)
        {
            var fileExists = File.Exists(filePath);

            if (fileExists)
                File.Delete(filePath);

            return fileExists;
        }

        public static string UnsafePathCombine(string root, params string[] parts)
        {
            // CUSTOM: Does not use StringBuilder
            return Path.Combine(root, Path.Combine(parts));
        }
    }
}
