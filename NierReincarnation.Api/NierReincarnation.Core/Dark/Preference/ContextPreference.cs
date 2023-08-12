namespace NierReincarnation.Core.Dark.Preference;

// Dark.Preference.ContextPreference
public class ContextPreference
{
    public static ContextPreference Instance = new ContextPreference();

    public int MasterDataVersion { get; set; }

    public string SessionKey { get; set; }

    public long SessionExpire { get; set; }
}
