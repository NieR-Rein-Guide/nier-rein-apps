namespace NierReincarnation.Core.Dark.Networking;

// Dark.Networking.NetworkInitializer
class NetworkInitializer
{
    public void Initialize(NetworkConfig config)
    {
        CalculatorNetworking.InitializeApiClient(config.MasterVersion, config.OriginalServerAddress, config.OriginalServerPort);
    }
}
