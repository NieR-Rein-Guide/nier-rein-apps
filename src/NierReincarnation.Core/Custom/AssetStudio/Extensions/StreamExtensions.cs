namespace NierReincarnation.Core.AssetStudio;

public static class StreamExtensions
{
    private const int BufferSize = 81920;

    public static void CopyTo(this Stream source, Stream destination, long size)
    {
        using MemoryStream buffer = new();
        source.CopyTo(buffer, (int)Math.Min(size, BufferSize));
        buffer.Seek(0, SeekOrigin.Begin);
        buffer.CopyTo(destination);
    }
}
