namespace NierReincarnation.Core.Dark.Preference;

public class ContextPreference
{
    public static ContextPreference Instance = new();

    public int MasterDataVersion { get; set; }

    public string SessionKey { get; set; }

    public long SessionExpire { get; set; }
}
