using NierReincarnation.Core.Octo.Util;
using MD5 = NierReincarnation.Core.Octo.Util.MD5;

namespace NierReincarnation.Core.Octo.Data;

internal class SecureFile
{
    private const string Tag = "Octo/SecureFile";

    protected AESCrypt _crypt;

    public string Path { get; set; }

    public SecureFile(string path, AESCrypt crypt)
    {
        Path = path;
        _crypt = crypt;
    }

    public BinaryReader GetReader()
    {
        if (!File.Exists(Path)) return null;

        var data = FileUtil.ReadAllBytes(Path);
        if (data == null || data.Length == 0)
        {
            return null;
        }

        MemoryStream ms = new(data, false);

        var cipherMode = ms.ReadByte();
        if (cipherMode == 0)
        {
            return new BinaryReader(ms);
        }

        if (cipherMode == 1)
        {
            var ms1 = CreateMode1ReadStream(ms);

            ms.Dispose();

            return new BinaryReader(ms1);
        }

        ms.Dispose();

        return null;
    }

    private MemoryStream CreateMode1ReadStream(MemoryStream cipherStream)
    {
        if (_crypt == null)
        {
            return null;
        }

        var decData = _crypt.Decrypt(cipherStream);
        if (decData == null || decData.Length <= 0xF)
        {
            return null;
        }

        MemoryStream ms = new(decData);
        var buffer = new byte[0x10];
        var _ = ms.Read(buffer);

        var dataHash = MD5.HashBytes(ms);
        if (Bytes.ByteArrayEqual(buffer, dataHash))
        {
            ms.Seek(buffer.Length, SeekOrigin.Begin);
            return ms;
        }

        ms.Dispose();

        return null;
    }

    public byte[] Load()
    {
        using var reader = GetReader();

        return reader?.ReadBytes((int)reader.BaseStream.Length);
    }

    public Error Save(byte[] plainBytes)
    {
        if (plainBytes == null)
        {
            return null;
        }

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
