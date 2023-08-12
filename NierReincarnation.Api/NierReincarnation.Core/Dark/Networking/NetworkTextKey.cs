namespace NierReincarnation.Core.Dark.Networking;

// Dark.Networking.NetworkTextKey APK Resource file: 1dc4624c9ddde409fb4ffb1b0cb2faeb
internal class NetworkTextKey
{
    //private static readonly ArtStringBuilder _artStringBuilder;
    public static readonly string kNetworkErrorTitleKey = "nt.Network.Error.Title";

    public static readonly string kNetworkDataUpdateErrorTitleKey = "nt.Network.Error.Title.DataUpdate";
    public static readonly string kNetworkLackCapacityKey = "nt.Network.Error.Message.LackCapacity";
    public static readonly string kNetworkFatalErrorKey = "nt.Network.Error.Message.FatalDownload";
    public static readonly string kNetworkMasterErrorKey = "nt.Network.Error.Message.MasterDownload";
    public static readonly string kNetworkAssetLoadErrorKey = "nt.Network.Error.Message.AssetLoad";
    public static readonly string kNetwrokBridgeUserError = "nt.Network.Error.Message.BridgeUser";
    public static readonly string kNetworkConnectError = "nt.Network.Error.Message.Connect";
    public static readonly string kNetworkAssetFatalError = "nt.Network.Error.Message.AssetFatalError";
    private static readonly string kNetworkErrorKeyRoot = "nt.Network.";
    public static readonly string kNetworkPermissionDeniedError = kNetworkErrorKeyRoot + "Error.Message.PermissionDenied";
    public static readonly string kNetworkBanKey = ConvertTextKey("102002");
    public static readonly string kNetworkCbtBanKey = ConvertTextKey("1020013");
    public static readonly string kNetworkTitleErrorKey = ConvertTextKey("900000");
    public static readonly string kNetworkStayErrorKey = ConvertTextKey("900001");
    public static readonly string kNetworkMessageErrorKey = ConvertTextKey("900002");

    public static string ConvertTextKey(string messageCode)
    {
        // TODO: Reverse more with ArtStringBuilder
        return kNetworkErrorKeyRoot + messageCode;
    }
}
