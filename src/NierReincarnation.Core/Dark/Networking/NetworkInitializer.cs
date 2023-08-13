namespace NierReincarnation.Core.Dark.Networking;

public class NetworkInitializer
{
    public void Initialize(NetworkConfig config)
    {
        CalculatorNetworking.InitializeApiClient(config.MasterVersion, config.OriginalServerAddress, config.OriginalServerPort);
    }
}
