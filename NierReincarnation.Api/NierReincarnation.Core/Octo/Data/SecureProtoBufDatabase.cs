using NierReincarnation.Core.Octo.Proto;

namespace NierReincarnation.Core.Octo.Data;

class SecureProtoBufDatabase<T> : SecureSerializableDatabase<T>
{
    public SecureProtoBufDatabase(string path, AESCrypt crypt) : base(path, crypt)
    {
    }

    protected override T Deserialize(byte[] bytes)
    {
        return StaticSerializer.Deserialize<T>(bytes);
    }
}
