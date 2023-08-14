using K4os.Compression.LZ4;

namespace NierReincarnation.Core.AssetStudio;

public class BundleFile
{
    public class Header
    {
        public uint CompressedBlocksInfoSize;
        public uint UncompressedBlocksInfoSize;
    }

    public class StorageBlock
    {
        public uint CompressedSize;
        public uint UncompressedSize;
    }

    public class Node
    {
        public long Offset;
        public long Size;
        public string Path;
    }

    private readonly Header HeaderInfo;
    private StorageBlock[] BlocksInfo;
    private Node[] DirectoryInfo;

    public List<Stream> FileStreams = new();

    public BundleFile(FileReader reader)
    {
        HeaderInfo = new Header();
        reader.ReadStringToNull();
        reader.ReadUInt32();
        reader.ReadStringToNull();
        reader.ReadStringToNull();

        ReadHeader(reader);
        ReadBlocksInfoAndDirectory(reader);
        using var blocksStream = CreateBlocksStream();
        ReadBlocks(reader, blocksStream);
        ReadFiles(blocksStream);
    }

    private Stream CreateBlocksStream()
    {
        var uncompressedSizeSum = BlocksInfo.Sum(x => x.UncompressedSize);
        return new MemoryStream((int)uncompressedSizeSum);
    }

    public void ReadFiles(Stream blocksStream)
    {
        for (int i = 0; i < DirectoryInfo.Length; i++)
        {
            var node = DirectoryInfo[i];
            var stream = new MemoryStream((int)node.Size);
            blocksStream.Position = node.Offset;
            blocksStream.CopyTo(stream, node.Size);
            stream.Position = 0;

            FileStreams.Add(stream);
        }
    }

    private void ReadHeader(EndianBinaryReader reader)
    {
        reader.ReadInt64();
        HeaderInfo.CompressedBlocksInfoSize = reader.ReadUInt32();
        HeaderInfo.UncompressedBlocksInfoSize = reader.ReadUInt32();
        reader.ReadUInt32();
    }

    private void ReadBlocksInfoAndDirectory(EndianBinaryReader reader)
    {
        byte[] blocksInfoBytes = reader.ReadBytes((int)HeaderInfo.CompressedBlocksInfoSize);
        MemoryStream blocksInfoUncompresseddStream;
        var uncompressedSize = HeaderInfo.UncompressedBlocksInfoSize;

        byte[] uncompressedBytes = new byte[uncompressedSize];
        LZ4Codec.Decode(blocksInfoBytes, uncompressedBytes);
        blocksInfoUncompresseddStream = new MemoryStream(uncompressedBytes);

        using EndianBinaryReader blocksInfoReader = new(blocksInfoUncompresseddStream);
        var uncompressedDataHash = blocksInfoReader.ReadBytes(16);
        var blocksInfoCount = blocksInfoReader.ReadInt32();
        BlocksInfo = new StorageBlock[blocksInfoCount];
        for (int i = 0; i < blocksInfoCount; i++)
        {
            BlocksInfo[i] = new StorageBlock
            {
                UncompressedSize = blocksInfoReader.ReadUInt32(),
                CompressedSize = blocksInfoReader.ReadUInt32()
            };
            blocksInfoReader.ReadUInt16();
        }

        var nodesCount = blocksInfoReader.ReadInt32();
        DirectoryInfo = new Node[nodesCount];
        for (int i = 0; i < nodesCount; i++)
        {
            DirectoryInfo[i] = new Node();
            DirectoryInfo[i].Offset = blocksInfoReader.ReadInt64();
            DirectoryInfo[i].Size = blocksInfoReader.ReadInt64();
            blocksInfoReader.ReadUInt32();
            DirectoryInfo[i].Path = blocksInfoReader.ReadStringToNull();
        }
    }

    private void ReadBlocks(EndianBinaryReader reader, Stream blocksStream)
    {
        foreach (var blockInfo in BlocksInfo)
        {
            var compressedSize = (int)blockInfo.CompressedSize;
            var compressedBytes = new byte[compressedSize];
            reader.Read(compressedBytes, 0, compressedSize);
            var uncompressedSize = (int)blockInfo.UncompressedSize;
            var uncompressedBytes = new byte[uncompressedSize];
            var numWrite = LZ4Codec.Decode(compressedBytes, 0, compressedSize, uncompressedBytes, 0, uncompressedSize);
            if (numWrite != uncompressedSize)
            {
                throw new IOException($"Lz4 decompression error, write {numWrite} bytes but expected {uncompressedSize} bytes");
            }
            blocksStream.Write(uncompressedBytes, 0, uncompressedSize);
        }
        blocksStream.Position = 0;
    }
}
