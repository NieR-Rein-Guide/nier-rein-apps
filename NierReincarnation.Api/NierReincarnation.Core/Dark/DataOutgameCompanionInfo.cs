using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark
{
    public class DataOutgameCompanionInfo
    {
        // 0x10
        public string UserCompanionUuid { get; set; }
        // 0x18
        public int CompanionId { get; set; }
        // 0x1C
        public AttributeType Attribute { get; set; }
        // 0x20
        public int Level { get; set; }
        // 0x28
        public ActorAssetId ActorAssetId { get; set; }
    }
}
