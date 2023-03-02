namespace NierReincarnation.Core.Dark.Networking
{
    // Dark.Networking.NetworkTextKey
    // APK Resource file: 1dc4624c9ddde409fb4ffb1b0cb2faeb
    class NetworkTextKey
    {
        //private static readonly ArtStringBuilder _artStringBuilder; // 0x0
        public static readonly string kNetworkErrorTitleKey = "nt.Network.Error.Title"; // 0x8
        public static readonly string kNetworkDataUpdateErrorTitleKey = "nt.Network.Error.Title.DataUpdate"; // 0x10
        public static readonly string kNetworkLackCapacityKey = "nt.Network.Error.Message.LackCapacity"; // 0x18
        public static readonly string kNetworkFatalErrorKey = "nt.Network.Error.Message.FatalDownload"; // 0x20
        public static readonly string kNetworkMasterErrorKey = "nt.Network.Error.Message.MasterDownload"; // 0x28
        public static readonly string kNetworkAssetLoadErrorKey = "nt.Network.Error.Message.AssetLoad"; // 0x30
        public static readonly string kNetwrokBridgeUserError = "nt.Network.Error.Message.BridgeUser"; // 0x38
        public static readonly string kNetworkConnectError = "nt.Network.Error.Message.Connect"; // 0x40
        public static readonly string kNetworkAssetFatalError = "nt.Network.Error.Message.AssetFatalError"; // 0x48
        private static readonly string kNetworkErrorKeyRoot = "nt.Network."; // 0x50
        public static readonly string kNetworkPermissionDeniedError = kNetworkErrorKeyRoot + "Error.Message.PermissionDenied"; // 0x58
        public static readonly string kNetworkBanKey = ConvertTextKey("102002"); // 0x60
        public static readonly string kNetworkCbtBanKey = ConvertTextKey("1020013"); // 0x68
        public static readonly string kNetworkTitleErrorKey = ConvertTextKey("900000"); // 0x70
        public static readonly string kNetworkStayErrorKey = ConvertTextKey("900001"); // 0x78
        public static readonly string kNetworkMessageErrorKey = ConvertTextKey("900002"); // 0x80

        public static string ConvertTextKey(string messageCode)
        {
            // TODO: Reverse more with ArtStringBuilder
            return kNetworkErrorKeyRoot + messageCode;
        }
    }
}
