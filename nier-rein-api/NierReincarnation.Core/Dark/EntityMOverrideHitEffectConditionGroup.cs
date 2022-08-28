using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_override_hit_effect_condition_group")]
    public class EntityMOverrideHitEffectConditionGroup
    {
        [Key(0)]
        public int OverrideHitEffectConditionGroupId { get; set; } // 0x10
        [Key(1)]
        public int ConditionIndex { get; set; } // 0x14
        [Key(2)]
        public int ConditionType { get; set; } // 0x18
        [Key(3)]
        public int OverrideHitEffectConditionId { get; set; } // 0x1C
    }
}