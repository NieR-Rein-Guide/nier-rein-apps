using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_proper_attribute_hp_bonus")]
    public class EntityMCostumeProperAttributeHpBonus
    {
        [Key(0)]
        public int CostumeId { get; set; } // 0x10

        [Key(1)]
        public AttributeType CostumeProperAttributeType { get; set; } // 0x14

        [Key(2)]
        public int MainWeaponHpAdditionalValue { get; set; } // 0x18

        [Key(3)]
        public int SubWeaponHpAdditionalValue { get; set; } // 0x1C
    }
}
