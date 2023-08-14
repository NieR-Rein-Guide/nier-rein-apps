namespace NierReincarnation.Core.AssetStudio;

public class FileReader : EndianBinaryReader
{
    public FileType FileType;

    public FileReader(string path) : this(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) { }

    public FileReader(Stream stream) : base(stream, EndianType.BigEndian)
    {
        FileType = CheckFileType();
    }

    private FileType CheckFileType()
    {
        string signature = this.ReadStringToNull(20);
        Position = 0;

        return signature switch
        {
            "UnityFS" => FileType.BundleFile,
            _ => FileType.AssetsFile,
        };
    }
}
