using System.Security.Cryptography;
using System.Text;

namespace NierReincarnation.Datamine.Extension;

public static class MasterDataExtensions
{
    public static byte[] DecryptMasterData(byte[] data)
    {
        Aes masterAes = Aes.Create();
        masterAes.Mode = CipherMode.CBC;
        masterAes.Key = Encoding.UTF8.GetBytes("6Cb01321EE5e6bBe");
        masterAes.IV = Encoding.UTF8.GetBytes("EfcAef4CAe5f6DaA");

        return masterAes.CreateDecryptor().TransformFinalBlock(data, 0, data.Length);
    }
}
