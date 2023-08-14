namespace NierReincarnation.Core.AssetStudio;

public class SerializedFile
{
    private readonly FileReader _fileReader;
    public List<ObjectInfo> Objects;

    public SerializedFile(FileReader fileReader)
    {
        _fileReader = fileReader;

        // ReadHeader
        fileReader.ReadUInt32();
        fileReader.ReadUInt32();
        fileReader.ReadUInt32();
        uint dataOffset = fileReader.ReadUInt32();
        fileReader.ReadByte();
        fileReader.ReadBytes(3);

        // ReadMetadata
        fileReader.Endian = EndianType.LittleEndian;
        fileReader.ReadStringToNull();
        fileReader.ReadInt32();
        fileReader.ReadBoolean();

        // Read Types
        int typeCount = fileReader.ReadInt32();
        List<int> classIds = new();
        for (int i = 0; i < typeCount; i++)
        {
            classIds.Add(ReadSerializedType());
        }

        // Read Objects
        int objectCount = fileReader.ReadInt32();
        Objects = new List<ObjectInfo>(objectCount);
        for (int i = 0; i < objectCount; i++)
        {
            ObjectInfo objectInfo = new()
            {
                ClassID = classIds[i]
            };

            fileReader.AlignStream();
            fileReader.ReadInt64();
            objectInfo.ByteStart = fileReader.ReadUInt32() + dataOffset;
            fileReader.ReadUInt32();
            fileReader.ReadInt32();

            Objects.Add(objectInfo);
        }
    }

    private int ReadSerializedType()
    {
        int classId = _fileReader.ReadInt32();
        _fileReader.ReadBoolean();
        _fileReader.ReadInt16();

        if (classId == 114)
        {
            _fileReader.ReadBytes(16);
        }
        _fileReader.ReadBytes(16);

        TypeTreeBlobRead();

        _fileReader.ReadInt32Array();

        return classId;
    }

    private void TypeTreeBlobRead()
    {
        int numberOfNodes = _fileReader.ReadInt32();
        int stringBufferSize = _fileReader.ReadInt32();
        for (int i = 0; i < numberOfNodes; i++)
        {
            _fileReader.ReadUInt16();
            _fileReader.ReadByte();
            _fileReader.ReadByte();
            _fileReader.ReadUInt32();
            _fileReader.ReadUInt32();
            _fileReader.ReadInt32();
            _fileReader.ReadInt32();
            _fileReader.ReadInt32();
            _fileReader.ReadUInt64();
        }
        _fileReader.ReadBytes(stringBufferSize);
    }
}
