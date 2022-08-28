using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_override_hit_effect_condition_skill_executor")]
    public class EntityMOverrideHitEffectConditionSkillExecutor
    {
        [Key(0)]
        public int OverrideHitEffectConditionId { get; set; } // 0x10
        [Key(1)]
        public int SkillOwnerCategoryType { get; set; } // 0x14
    }
}