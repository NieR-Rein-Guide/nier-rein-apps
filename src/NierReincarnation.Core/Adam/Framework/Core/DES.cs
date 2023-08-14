using System.Security.Cryptography;
using NativeDES = System.Security.Cryptography.DES;

namespace NierReincarnation.Core.Adam.Framework.Core;

public static class DES
{
    public static string Decryption(string encryptedString, string key)
    {
        using MemoryStream ms = new(Convert.FromBase64String(encryptedString));
        using CryptoStream cs = new(ms, GetDES(key).CreateDecryptor(), CryptoStreamMode.Read);
        using StreamReader sr = new(cs, Encoding.ASCII);

        return sr.ReadToEnd();
    }

    public static string Encryption(string plain, string key)
    {
        using MemoryStream ms = new();
        using CryptoStream cs = new(ms, GetDES(key).CreateEncryptor(), CryptoStreamMode.Write);

        cs.Write(Encoding.Default.GetBytes(plain));
        cs.FlushFinalBlock();

        return Convert.ToBase64String(ms.ToArray());
    }

    private static NativeDES GetDES(string key)
    {
        NativeDES des = NativeDES.Create();
        des.Mode = CipherMode.ECB;
        des.Padding = PaddingMode.PKCS7;
        des.Key = Encoding.ASCII.GetBytes(key);

        return des;
    }
}
