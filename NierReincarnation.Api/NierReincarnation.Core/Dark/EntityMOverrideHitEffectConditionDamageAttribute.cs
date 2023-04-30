using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_override_hit_effect_condition_damage_attribute")]
    public class EntityMOverrideHitEffectConditionDamageAttribute
    {
        [Key(0)]
        public int OverrideHitEffectConditionId { get; set; } // 0x10

        [Key(1)]
        public bool IsExcepting { get; set; } // 0x14

        [Key(2)]
        public int AttributeType { get; set; } // 0x18
    }
}
