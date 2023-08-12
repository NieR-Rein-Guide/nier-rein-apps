using System.Security.Cryptography;
using MD5 = NierReincarnation.Core.Octo.Util.MD5;

namespace NierReincarnation.Core.Octo.Data;

internal class AESCrypt
{
    private static readonly List<int> ValidKeyLengths = new() { 128, 196, 256 };

    private const string IV = "LvAUtf+tnz";
    private readonly Aes _aesAlgo;

    public AESCrypt(byte[] key, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        if (!ValidKeyLengths.Contains(key.Length << 3))
            throw new ArgumentException("Key must be exactly 128/192/256 bytes long!");

        _aesAlgo = Aes.Create();
        _aesAlgo.Key = key;
        _aesAlgo.IV = MD5.HashBytes(IV);
        _aesAlgo.Mode = cipherMode;
        _aesAlgo.Padding = paddingMode;
    }

    public AESCrypt(string key, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7) :
        this(MD5.HashBytes(key), cipherMode, paddingMode)
    {
    }

    public void UpdateIV(byte[] iv)
    {
        _aesAlgo.IV = iv;
    }

    public byte[] Decrypt(MemoryStream memoryStream)
    {
        var buffer = new byte[memoryStream.Length];

        using CryptoStream cs = new(memoryStream, _aesAlgo.CreateDecryptor(), CryptoStreamMode.Read);
        using BinaryReader br = new(cs);

        int actualLength = 0;
        while (actualLength < buffer.Length)
        {
            int bytesRead = br.Read(buffer, actualLength, buffer.Length - actualLength);
            if (bytesRead == 0) break;
            actualLength += bytesRead;
        }

        Array.Resize(ref buffer, actualLength);
        return buffer;
    }

    public byte[] Encrypt(byte[] plainTextBytes)
    {
        return _Encrypt(plainTextBytes);
    }

    private byte[] _Encrypt(byte[] plainTextBytes)
    {
        using MemoryStream result = new();

        using (CryptoStream cs = new(result, _aesAlgo.CreateEncryptor(), CryptoStreamMode.Write))
        using (BinaryWriter bw = new(cs))
            bw.Write(plainTextBytes);

        return result.ToArray();
    }
}
