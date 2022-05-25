using System.IO;
using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.Octo.Data
{
    class SecureFile
    {
        private static readonly string Tag = "Octo/SecureFile"; // 0x0

        protected AESCrypt _crypt; // 0x18

        // 0x10
        public string Path { get; set; }

        public SecureFile(string path, AESCrypt crypt)
        {
            Path = path;
            _crypt = crypt;
        }

        public BinaryReader GetReader()
        {
            if (!File.Exists(Path))
                return null;

            var data = FileUtil.ReadAllBytes(Path);
            if (data == null || data.Length == 0)
            {
                // Log error with OctoManager+0x18 with message ('Secure file is empty: {0}', Tag)
                return null;
            }

            var ms = new MemoryStream(data, false);

            var cipherMode = ms.ReadByte();
            if (cipherMode == 0)
                return new BinaryReader(ms);

            if (cipherMode == 1)
            {
                var ms1 = CreateMode1ReadStream(ms);

                ms.Dispose();

                return new BinaryReader(ms1);
            }

            // Log error with OctoManager+0x18 with message (Tag, ('Unknown cipher mode: {0}', s))
            ms.Dispose();

            return null;
        }

        private MemoryStream CreateMode1ReadStream(MemoryStream cipherStream)
        {
            if (_crypt == null)
            {
                // Log error with OctoManager+0x18 with message (Tag, ('Secure file is encrypted while AES is not set, mode={0}', Mode.AESWithMD5))
                return null;
            }

            var decData = _crypt.Decrypt(cipherStream);
            if (decData == null || decData.Length <= 0xF)
            {
                // Log error with OctoManager+0x18 with message (Tag, ('Secure file is corrupt: {0}', Path))
                return null;
            }

            var ms = new MemoryStream(decData);
            var buffer = new byte[0x10];
            var _ = ms.Read(buffer);

            var dataHash = MD5.HashBytes(ms);
            if (Bytes.ByteArrayEqual(buffer, dataHash))
            {
                ms.Seek(buffer.Length, SeekOrigin.Begin);
                return ms;
            }

            // Log error with OctoManager+0x18 with message (Tag, ('Secure file has been tampered with: {0}', Path))
            ms.Dispose();

            return null;
        }

        public byte[] Load()
        {
            using var reader = GetReader();

            var data = reader?.ReadBytes((int)reader.BaseStream.Length);

            return data;
        }

        public Error Save(byte[] plainBytes)
        {
            if (plainBytes == null)
                return null;

            var b = new byte[1];
            if (_crypt != null)
            {
                b[0] = 1;

                var hash = MD5.HashBytes(plainBytes);
                var fileData = Bytes.CombineArrays(hash, plainBytes);

                if (_crypt != null)
                    plainBytes = _crypt.Encrypt(fileData);
            }

            FileUtil.CreateDirectory(Path);
            return FileUtil.WriteAllBytes(Path, b, plainBytes);
        }

        public enum Mode : byte
        {
            Raw = 0,
            AESWithMD5 = 1
        }
    }
}
