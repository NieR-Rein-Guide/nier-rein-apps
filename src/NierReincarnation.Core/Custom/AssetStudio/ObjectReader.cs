namespace NierReincarnation.Core.AssetStudio;

public class ObjectReader : EndianBinaryReader
{
    public long ByteStart;
    public ClassIDType Type;

    public ObjectReader(EndianBinaryReader reader, ObjectInfo objectInfo) : base(reader.BaseStream, reader.Endian)
    {
        ByteStart = objectInfo.ByteStart;
        Type = Enum.IsDefined(typeof(ClassIDType), objectInfo.ClassID)
            ? (ClassIDType)objectInfo.ClassID
            : ClassIDType.UnknownType;
    }

    public void Reset()
    {
        Position = ByteStart;
    }
}
