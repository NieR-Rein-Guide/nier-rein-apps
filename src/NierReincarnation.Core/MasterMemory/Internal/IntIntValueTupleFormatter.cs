﻿using MessagePack.Formatters;

namespace NierReincarnation.Core.MasterMemory.Internal;

public class IntIntValueTupleFormatter : IMessagePackFormatter<(int, int)>
{
    public void Serialize(ref MessagePackWriter writer, (int, int) value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(2);
        writer.WriteInt32(value.Item1);
        writer.WriteInt32(value.Item2);
    }

    public (int, int) Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
        {
            throw new InvalidOperationException("Data is Nil, ValueTuple can not be null.");
        }

        var header = reader.ReadArrayHeader();
        return header == 2 ? (reader.ReadInt32(), reader.ReadInt32()) : throw new InvalidOperationException("Invalid ValueTuple count");
    }
}
