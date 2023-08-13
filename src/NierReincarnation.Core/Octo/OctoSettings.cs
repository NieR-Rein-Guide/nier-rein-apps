namespace NierReincarnation.Core.Octo;

public sealed class OctoSettings : IOctoSettings
{
    public string Url { get; }

    public int AppId { get; }

    public string ClientSecretKey { get; }

    public string AesKey { get; }

    public string A { get; }

    public CachingType CachingType { get; }

    public int Version { get; }

    public int MaxParallelDownload { get; }

    public int MaxParallelLoad { get; }
}
