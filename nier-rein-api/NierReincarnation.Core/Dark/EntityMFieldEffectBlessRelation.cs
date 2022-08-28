using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_field_effect_bless_relation")]
    public class EntityMFieldEffectBlessRelation
    {
        [Key(0)]
        public int FieldEffectGroupId { get; set; } // 0x10
        [Key(1)]
        public int FieldEffectBlessRelationIndex { get; set; } // 0x14
        [Key(2)]
        public int WeaponId { get; set; } // 0x18
    }
}