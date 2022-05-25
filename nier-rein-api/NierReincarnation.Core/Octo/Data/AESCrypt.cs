using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using MD5 = NierReincarnation.Core.Octo.Util.MD5;

namespace NierReincarnation.Core.Octo.Data
{
    class AESCrypt
    {
        // Fields
        private static readonly List<int> ValidKeyLengths = new List<int> { 128, 196, 256 }; // 0x0
        private static readonly string IV = "LvAUtf+tnz"; // 0x8
        private Aes _aesAlgo; // 0x10

        // Methods

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

            using var cs = new CryptoStream(memoryStream, _aesAlgo.CreateDecryptor(), CryptoStreamMode.Read);
            using var br = new BinaryReader(cs);

            var actualLength = br.Read(buffer, 0, buffer.Length);

            Array.Resize(ref buffer, actualLength);
            return buffer;
        }

        public byte[] Encrypt(byte[] plainTextBytes)
        {
            return _Encrypt(plainTextBytes);
        }

        private byte[] _Encrypt(byte[] plainTextBytes)
        {
            using var result = new MemoryStream();

            using (var cs = new CryptoStream(result, _aesAlgo.CreateEncryptor(), CryptoStreamMode.Write))
            using (var bw = new BinaryWriter(cs))
                bw.Write(plainTextBytes);

            return result.ToArray();
        }
    }
}
