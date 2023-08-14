namespace NierReincarnation.Core.Dark;

/// <summary>
/// User gets set by Dark.Networking.DataSource.User.UserDataGet. Master gets set by Art.Library.Masterdata.MasterDataDownloader.
/// </summary>
public static class DatabaseDefine
{
    public static DarkUserMemoryDatabase User { get; set; }

    public static DarkMasterMemoryDatabase Master { get; set; }
}
