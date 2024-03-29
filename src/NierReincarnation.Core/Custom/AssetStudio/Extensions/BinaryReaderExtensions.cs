﻿namespace NierReincarnation.Core.AssetStudio;

public static class BinaryReaderExtensions
{
    public static void AlignStream(this BinaryReader reader)
    {
        reader.AlignStream(4);
    }

    public static void AlignStream(this BinaryReader reader, int alignment)
    {
        var pos = reader.BaseStream.Position;
        var mod = pos % alignment;
        if (mod != 0)
        {
            reader.BaseStream.Position += alignment - mod;
        }
    }

    public static string ReadAlignedString(this BinaryReader reader)
    {
        var length = reader.ReadInt32();
        if (length > 0 && length <= reader.BaseStream.Length - reader.BaseStream.Position)
        {
            var stringData = reader.ReadBytes(length);
            var result = Encoding.UTF8.GetString(stringData);
            reader.AlignStream(4);
            return result;
        }
        return "";
    }

    public static string ReadStringToNull(this BinaryReader reader, int maxLength = 32767)
    {
        var bytes = new List<byte>();
        int count = 0;
        while (reader.BaseStream.Position != reader.BaseStream.Length && count < maxLength)
        {
            var b = reader.ReadByte();
            if (b == 0)
            {
                break;
            }
            bytes.Add(b);
            count++;
        }
        return Encoding.UTF8.GetString(bytes.ToArray());
    }

    private static T[] ReadArray<T>(Func<T> del, int length)
    {
        var array = new T[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = del();
        }
        return array;
    }

    public static byte[] ReadUInt8Array(this BinaryReader reader)
    {
        return reader.ReadBytes(reader.ReadInt32());
    }

    public static int[] ReadInt32Array(this BinaryReader reader)
    {
        return ReadArray(reader.ReadInt32, reader.ReadInt32());
    }
}
