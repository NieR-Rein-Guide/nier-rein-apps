using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_specific_limit_break_material_group")]
    public class EntityMWeaponSpecificLimitBreakMaterialGroup
    {
        [Key(0)]
        public int WeaponSpecificLimitBreakMaterialGroupId { get; set; } // 0x10

        [Key(1)]
        public int LimitBreakCountLowerLimit { get; set; } // 0x14

        [Key(2)]
        public int MaterialId { get; set; } // 0x18

        [Key(3)]
        public int Count { get; set; } // 0x1C

        [Key(4)]
        public int SortOrder { get; set; } // 0x20
    }
}
