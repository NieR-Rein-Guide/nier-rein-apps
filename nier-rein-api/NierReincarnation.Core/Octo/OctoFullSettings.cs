namespace NierReincarnation.Core.Octo
{
    class OctoFullSettings : IOctoSettings
    {
        // 0x10
        public string Url { get; set; }
		// 0x18
        public int AppId { get; set; }
		// 0x20
        public string ClientSecretKey { get; set; }
		// 0x28
        public string AesKey { get; set; }
		// 0x30
        public string A { get; set; }
		// 0x38
        public CachingType CachingType { get; set; }
		// 0x3C
        public int Version { get; set; }
        //public IUnloadHandler UnloadHandler { get; set; }
		// 0x48
        public int MaxParallelDownload { get; set; }
		// 0x4C
        public int MaxParallelLoad { get; set; }
        // 0x50
        public long MaximumAvailableDiskSpace { get; set; }
        // 0x58
        public int ExpirationDelay { get; set; }
        // 0x5C
        public bool AllowDeleted { get; set; }
        // 0x5D
        public bool EnableAssetDatabase { get;set; }
		// 0x5E
        public AssetLoader.LoadPriority AssetLoaderPriority { get; set; }

		public OctoFullSettings() { }

        public OctoFullSettings(OctoSettings settings)
        {
            
        }
    }
}
