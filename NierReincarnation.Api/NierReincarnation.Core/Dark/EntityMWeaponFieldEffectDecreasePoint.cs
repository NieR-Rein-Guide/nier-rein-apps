using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_field_effect_decrease_point")]
    public class EntityMWeaponFieldEffectDecreasePoint
    {
        [Key(0)]
        public int WeaponId { get; set; }

        [Key(1)]
        public int RelationIndex { get; set; }

        [Key(2)]
        public int FieldEffectGroupId { get; set; }

        [Key(3)]
        public int FieldEffectAbilityId { get; set; }

        [Key(4)]
        public int DecreasePoint { get; set; }

        [Key(5)]
        public int WeaponAbilityId { get; set; }

        [Key(6)]
        public bool IsWeaponAwaken { get; set; }

        [Key(7)]
        public int AutoOrganizationCoefficientPermil { get; set; }
    }
}
