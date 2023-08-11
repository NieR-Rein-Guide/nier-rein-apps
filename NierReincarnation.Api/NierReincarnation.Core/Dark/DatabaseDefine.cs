namespace NierReincarnation.Core.Dark;

// User gets set by Dark.Networking.DataSource.User.UserDataGet
// Master gets set by Art.Library.Masterdata.MasterDataDownloader
public static class DatabaseDefine
{
   
    public static DarkUserMemoryDatabase User { get; set; }
   
    public static DarkMasterMemoryDatabase Master { get; set; }
}
