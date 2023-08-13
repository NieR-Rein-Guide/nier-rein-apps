namespace NierReincarnation.Core.Dark.Networking;

public class NetworkConfig
{
    private static readonly int InvalidPort;

    public int MasterVersion { get; set; }

    private string _serverAddress;

    private int _serverPort;

    public ServerTimeZone ServerTimeZone { get; set; }

    public static TimeZoneInfo TimeZone => CreateTimeZoneInfo(KernelState.NetworkConfig.ServerTimeZone);

    public string ServerAddress
    {
        get
        {
            if (!string.IsNullOrEmpty(_serverAddress))
                return _serverAddress;

            return _serverAddress = EntryPoint.Config.Api.Hostname;
        }

        set => _serverAddress = value;
    }

    public int ServerPort
    {
        get
        {
            if (_serverPort != InvalidPort)
                return _serverPort;

            return _serverPort = EntryPoint.Config.Api.Port;
        }

        set => _serverPort = value;
    }

    public string OriginalServerAddress
    {
        get
        {
            if (!string.IsNullOrEmpty(_serverAddress))
                return _serverAddress;

            return _serverAddress = EntryPoint.Config.Api.Hostname;
        }
    }

    public int OriginalServerPort
    {
        get
        {
            if (_serverPort != InvalidPort)
                return _serverPort;

            return _serverPort = EntryPoint.Config.Api.Port;
        }
    }

    public override string ToString()
    {
        var output = "NetworkConfig --------- MasterVersion=" + MasterVersion;
        output += ", ServerAddress=" + OriginalServerAddress;
        output += ", ServerPort=" + OriginalServerPort;

        return output;
    }

    private static TimeZoneInfo CreateTimeZoneInfo(ServerTimeZone timeZone)
    {
        return timeZone switch
        {
            ServerTimeZone.Tokyo => TimeZoneInfo.CreateCustomTimeZone("D_Japan", new TimeSpan(9, 0, 0), "D_Japan", "D_Japan"),
            ServerTimeZone.US_Eastern => TimeZoneInfo.CreateCustomTimeZone("D_UTC", new TimeSpan(0, 0, 0), "D_UTC", "D_UTC"),
            ServerTimeZone.UTC => TimeZoneInfo.CreateCustomTimeZone("D_America/New_York", new TimeSpan(-5, 0, 0), "D_America/New_York", "D_America/New_York"),
            _ => throw new ArgumentOutOfRangeException(nameof(timeZone)),
        };
    }
}
