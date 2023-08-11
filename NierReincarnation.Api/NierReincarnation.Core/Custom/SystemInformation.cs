namespace NierReincarnation.Core.Custom
{
    public class SystemInformation
    {
        //public string AppVersion { get; set; } = "2.4.0";  // UnityEngine.Application$$get_version(0)
        //public string Language { get; set; } = "English";    // Dark.Kernel.Language$$GetLanguageString(0); UnityEngine.Application$$get_systemLanguage(0);
        //public string OsVersion { get; set; } = "Android OS 7.1.1 / API-23 (NMF26F/136)";   // UnityEngine.SystemInfo$$get_operatingSystem(0);
        //public string DeviceName { get; set; } = "OnePlus ONEPLUS A3010";  // UnityEngine.SystemInfo$$get_deviceModel(0);
        //public int PlatformId { get; set; } = 2;     // UnityEngine.Application$$get_platform(0);
        public string AdjustId { get; set; } = "";    // com.adjust.sdk.Adjust$$getAdid(0);

        //public string DeviceId { get; set; } = "35709d2a3c52d02388d12e88535f8aa0";    // UnityEngine.SystemInfo$$get_deviceUniqueIdentifier(0);
        public string KeyChainUserId { get; set; } = "";  // Unknown origin ("value = **(long **)(string_TypeInfo + 0xb8);" in code)

        public static SystemInformation Instance { get; } = new SystemInformation();
    }
}
