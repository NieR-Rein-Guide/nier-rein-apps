using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.Octo.Caching;

internal class OctoAppCaching
{
    private const string Tag = "OctoAppCaching";
    private const string OctoDir = "Octo";
    private const string ListFileName = "l";

    private readonly Dictionary<string, EmbeddedInfo> _embeddedDictionary;
    private readonly string _rootDir;

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
        return _embeddedDictionary.TryGetValue(bucket, out var value) && (value.generation >= generation || value.md5.Equals(md5));
    }

    public string GetFilePath(string bucket, Item item)
    {
        throw new NotImplementedException();
    }

    private struct EmbeddedInfo
    {
        public ulong generation;

        public MD5Value md5;
    }
}
