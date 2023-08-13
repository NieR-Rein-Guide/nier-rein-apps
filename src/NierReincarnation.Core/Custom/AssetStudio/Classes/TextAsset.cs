namespace NierReincarnation.Core.AssetStudio;

public sealed class TextAsset
{
    public static readonly TextAsset Empty = new();

    public string Name;

    public byte[] Bytes;

    public string Text { get; } = string.Empty;

    public TextAsset()
    { }

    public TextAsset(ObjectReader reader)
    {
        reader.Reset();
        Name = reader.ReadAlignedString();
        Bytes = reader.ReadUInt8Array();
        Text = Encoding.UTF8.GetString(Bytes);
    }
}
