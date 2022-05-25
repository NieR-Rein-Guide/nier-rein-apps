namespace NierReincarnation.Core.Dark.Preference
{
    // Dark.Preference.ContextPreference
    class ContextPreference
    {
        public static ContextPreference Instance = new ContextPreference();

        // 0x10
        public int MasterDataVersion { get; set; }
        // 0x18
        public string SessionKey { get; set; }
        // 0x20
        public long SessionExpire { get; set; }
    }
}
