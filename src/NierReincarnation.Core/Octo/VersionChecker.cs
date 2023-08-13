using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.Octo;

public static class VersionChecker
{
    private const string Tag = "Octo/VersionChecker";
    private const string VersionFileName = "v";

    public static bool Check(int version)
    {
        var path = Path.Combine(FileUtil.GetDatabaseRoot(), VersionFileName);

        var localVersion = 0;
        if (File.Exists(path))
        {
            var data = Bytes.ReverseIfNotLittleEndian(FileUtil.ReadAllBytes(path));

            localVersion = BitConverter.ToInt32(data);
        }

        if (localVersion >= version)
        {
            return false;
        }

        Migration(localVersion);

        FileUtil.WriteAllBytes(path, new[] { Bytes.ReverseIfNotLittleEndian(BitConverter.GetBytes(version)) });
        return true;
    }

    private static void Migration(int version)
    {
        if (version >= 0x20004) return;

        OctoManager.Internal._dataManager.DeleteData();
    }
}
