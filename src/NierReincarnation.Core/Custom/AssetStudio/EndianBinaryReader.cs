using System.Buffers.Binary;

namespace NierReincarnation.Core.AssetStudio;

public class EndianBinaryReader : BinaryReader
{
    private readonly byte[] buffer;

    public EndianType Endian;

    public EndianBinaryReader(Stream stream, EndianType endian = EndianType.BigEndian) : base(stream)
    {
        Endian = endian;
        buffer = new byte[8];
    }

    public long Position
    {
        get => BaseStream.Position;
        set => BaseStream.Position = value;
    }

    public override short ReadInt16()
    {
        if (Endian == EndianType.BigEndian)
        {
            Read(buffer, 0, 2);
            return BinaryPrimitives.ReadInt16BigEndian(buffer);
        }
        return base.ReadInt16();
    }

    public override int ReadInt32()
    {
        if (Endian == EndianType.BigEndian)
        {
            Read(buffer, 0, 4);
            return BinaryPrimitives.ReadInt32BigEndian(buffer);
        }
        return base.ReadInt32();
    }

    public override long ReadInt64()
    {
        if (Endian == EndianType.BigEndian)
        {
            Read(buffer, 0, 8);
            return BinaryPrimitives.ReadInt64BigEndian(buffer);
        }
        return base.ReadInt64();
    }

    public override ushort ReadUInt16()
    {
        if (Endian == EndianType.BigEndian)
        {
            Read(buffer, 0, 2);
            return BinaryPrimitives.ReadUInt16BigEndian(buffer);
        }
        return base.ReadUInt16();
    }

    public override uint ReadUInt32()
    {
        if (Endian == EndianType.BigEndian)
        {
            Read(buffer, 0, 4);
            return BinaryPrimitives.ReadUInt32BigEndian(buffer);
        }
        return base.ReadUInt32();
    }

    public override ulong ReadUInt64()
    {
        if (Endian == EndianType.BigEndian)
        {
            Read(buffer, 0, 8);
            return BinaryPrimitives.ReadUInt64BigEndian(buffer);
        }
        return base.ReadUInt64();
    }
}
