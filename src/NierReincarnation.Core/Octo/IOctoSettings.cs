namespace NierReincarnation.Core.Octo;

internal interface IOctoSettings
{
    string Url { get; }

    int AppId { get; }

    string ClientSecretKey { get; }

    string AesKey { get; }

    string A { get; }

    CachingType CachingType { get; }

    int Version { get; }

    //IUnloadHandler UnloadHandler { get; }
    int MaxParallelDownload { get; }

    int MaxParallelLoad { get; }
}
