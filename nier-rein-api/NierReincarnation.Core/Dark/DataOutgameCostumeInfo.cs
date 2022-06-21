using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark
{
    public class DataOutgameCostumeInfo
    {
        // 0x10
        public string UserCostumeUuid { get; set; }
        // 0x18
        public int CharacterId { get; set; }
        // 0x1C
        public int CostumeId { get; set; }
        // 0x20
        public WeaponType WeaponType { get; set; }
        // 0x24
        public RarityType RarityType { get; set; }
        // 0x28
        public int Level { get; set; }
        // 0x30
        public ActorAssetId ActorAssetId { get; set; }
    }
}
