using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Octo.Util;

internal static class FileUtil
{
    private const string Tag = "Octo/FileUtil";
    private const string OctoDirectory = "octo";
    private const string CacheDirectory = "Caches";
    private static string _mobileRootPath;

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

    // Note: Implementation by observation of behavior
    private static string GetAndroidOctoRoot()
    {
        string octoRoot = Path.Combine(Application.DataPath, "files", OctoDirectory);
        Directory.CreateDirectory(octoRoot);

        return octoRoot;
    }

    public static byte[] ReadAllBytes(string path)
    {
        return File.ReadAllBytes(path);
    }

    public static Error WriteAllBytes(string path, params byte[][] data)
    {
        using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        foreach (var dat in data)
        {
            fileStream.Write(dat);
        }

        return null;
    }

    public static bool FileDelete(string filePath)
    {
        bool fileExists = File.Exists(filePath);

        if (fileExists)
        {
            File.Delete(filePath);
        }

        return fileExists;
    }

    public static string UnsafePathCombine(string root, params string[] parts)
    {
        // Note: Not using StringBuilder
        return Path.Combine(root, Path.Combine(parts));
    }
}
