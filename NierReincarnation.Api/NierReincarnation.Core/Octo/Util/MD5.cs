namespace NierReincarnation.Core.Octo.Util;

internal static class MD5
{
    public static byte[] HashBytes(MemoryStream stream) => System.Security.Cryptography.MD5.HashData(stream);

    public static byte[] HashBytes(byte[] bytes) => System.Security.Cryptography.MD5.HashData(bytes);

    public static byte[] HashBytes(string text) => System.Security.Cryptography.MD5.HashData(Bytes.StringToByteArray(text));
}
