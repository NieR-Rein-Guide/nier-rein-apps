using System.IO;
using ProtoBuf;

namespace NierReincarnation.Core.Octo.Proto
{
    static class StaticSerializer
    {
        // CUSTOM: Not necessary, see Deserialize<T>(MemoryStream stream)
        //private static OCTProtoSerializer _serializer = new OCTProtoSerializer();

        public static T Deserialize<T>(byte[] binary)
        {
            using var ms = new MemoryStream(binary);
            return Deserialize<T>(ms);
        }

        public static T Deserialize<T>(MemoryStream stream)
        {
            // CUSTOM: Does not use original code, due to outdated version of protobuf library used in the game
            return Serializer.Deserialize<T>(stream);
        }
    }
}
