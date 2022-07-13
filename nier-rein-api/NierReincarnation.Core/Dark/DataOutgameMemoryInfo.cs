using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark
{
    // CUSTOM
    public class DataOutgameMemoryInfo
    {
        // 0x10
        public string UserMemoryUuid { get; set; }
        // 0x18
        public int PartsId { get; set; }
        // 0x1C
        public int GroupAssetId { get; set; }
        // 0x20
        public RarityType RarityType { get; set; }
    }
}
