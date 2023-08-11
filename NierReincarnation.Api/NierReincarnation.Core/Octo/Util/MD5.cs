using System.IO;
using System.Security.Cryptography;

namespace NierReincarnation.Core.Octo.Util;

static class MD5
{
    private static readonly MD5CryptoServiceProvider MD5Crpyto = new MD5CryptoServiceProvider();

    // Methods

    // RVA: 0x3EC9020 Offset: 0x3EC9020 VA: 0x3EC9020
    public static byte[] HashBytes(MemoryStream stream)
    {
        return MD5Crpyto.ComputeHash(stream);
    }

    // RVA: 0x3EC909C Offset: 0x3EC909C VA: 0x3EC909C
    public static byte[] HashBytes(byte[] bytes)
    {
        return MD5Crpyto.ComputeHash(bytes);
    }

    // RVA: 0x3EC9118 Offset: 0x3EC9118 VA: 0x3EC9118
    public static byte[] HashBytes(string text)
    {
        return MD5Crpyto.ComputeHash(Bytes.StringToByteArray(text));
    }
}
