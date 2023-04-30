using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_field_effect_decrease_point")]
    public class EntityMWeaponFieldEffectDecreasePoint
    {
        [Key(0)]
        public int WeaponId { get; set; } // 0x10

        [Key(1)]
        public int RelationIndex { get; set; } // 0x14

        [Key(2)]
        public int FieldEffectGroupId { get; set; } // 0x18

        [Key(3)]
        public int FieldEffectAbilityId { get; set; } // 0x1C

        [Key(4)]
        public int DecreasePoint { get; set; } // 0x20

        [Key(5)]
        public int WeaponAbilityId { get; set; } // 0x24

        [Key(6)]
        public bool IsWeaponAwaken { get; set; } // 0x28
    }
}
