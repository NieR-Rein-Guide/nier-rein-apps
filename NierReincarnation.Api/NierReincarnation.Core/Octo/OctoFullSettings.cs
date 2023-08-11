namespace NierReincarnation.Core.Octo;

public class OctoFullSettings : IOctoSettings
{
    public string Url { get; set; }

    public int AppId { get; set; }

    public string ClientSecretKey { get; set; }

    public string AesKey { get; set; }

    public string A { get; set; }

    public CachingType CachingType { get; set; }

    public int Version { get; set; }

    //public IUnloadHandler UnloadHandler { get; set; }

    public int MaxParallelDownload { get; set; }

    public int MaxParallelLoad { get; set; }

    public long MaximumAvailableDiskSpace { get; set; }

    public int ExpirationDelay { get; set; }

    public bool AllowDeleted { get; set; }

    public bool EnableAssetDatabase { get; set; }

    public AssetLoader.LoadPriority AssetLoaderPriority { get; set; }

    public OctoFullSettings()
    { }

    public OctoFullSettings(OctoSettings settings)
    {
    }
}
