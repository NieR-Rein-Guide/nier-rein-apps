using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NierReincarnation.Core.Adam.Framework.Core
{
    // Adam.Framework.Core.DES
    class DES
    {
        // Done
        public string Decryption(string encryptedString, string key)
        {
            var des = new DESCryptoServiceProvider
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7,
                Key = Encoding.ASCII.GetBytes(key)
            };

            using var ms = new MemoryStream(Convert.FromBase64String(encryptedString));
            using var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs, Encoding.ASCII);

            return sr.ReadToEnd();
        }

        // Done
        public string Encryption(string plain, string key)
        {
            var des = new DESCryptoServiceProvider
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7,
                Key = Encoding.ASCII.GetBytes(key)
            };

            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(Encoding.Default.GetBytes(plain));
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
