namespace NierReincarnation.Core.DeviceUtil;

public static class DeviceUtil
{
    private static string _mdcs;

    public static bool GetIjb() => false;

    public static bool GetHig() => false;

    public static string GetAcs() => string.Empty;

    public static bool GetPer() => false;

    public static bool GetImu() => false;

    public static bool GetIr() => false;

    public static bool GetIda() => false;

    public static string[] GetMsl() => Array.Empty<string>();

    public static string GetIcs() => string.Empty;

    public static void SetMdcs(string version, string checksum) => _mdcs = $"{{\"v\": \"{version}\", \"cs\": \"{checksum}\"}}";
}
