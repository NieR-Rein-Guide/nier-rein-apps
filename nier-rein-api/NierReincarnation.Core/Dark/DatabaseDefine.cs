namespace NierReincarnation.Core.Dark
{
    // User gets set by Dark.Networking.DataSource.User.UserDataGet
    // Master gets set by Art.Library.Masterdata.MasterDataDownloader
    public static class DatabaseDefine
    {
        // 0x00
        public static DarkUserMemoryDatabase User { get; set; }
        // 0x08
        public static DarkMasterMemoryDatabase Master { get; set; }
    }
}
