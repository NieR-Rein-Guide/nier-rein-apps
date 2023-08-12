using ProtoBuf;

namespace NierReincarnation.Core.Octo.Proto;

internal static class StaticSerializer
{
    public static T Deserialize<T>(byte[] binary)
    {
        using MemoryStream ms = new(binary);
        return Deserialize<T>(ms);
    }

    public static T Deserialize<T>(MemoryStream stream)
    {
        // Note: Does not use original code, due to outdated version of protobuf library used in the game
        return Serializer.Deserialize<T>(stream);
    }
}
