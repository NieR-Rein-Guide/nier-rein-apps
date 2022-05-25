namespace NierReincarnation.Core.Octo
{
    // Class used as Unity-Resource loaded type for DarkOctoSetupper._overwriteSettings 
    class OctoSettings : IOctoSettings
    {
        // 0x18
        public string Url { get; }
        // 0x20
        public int AppId { get; }
        // 0x28
        public string ClientSecretKey { get; }
        // 0x30
        public string AesKey { get; }
        // 0x38
        public string A { get; }
        // 0x40
        public CachingType CachingType { get; }
        // 0x44
        public int Version { get; }
        // 0x4C
        public int MaxParallelDownload { get; }
        // 0x50
        public int MaxParallelLoad { get; }
    }
}
