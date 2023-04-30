using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour_action_hit_ratio_down")]
    public class EntityMSkillAbnormalBehaviourActionHitRatioDown
    {
        [Key(0)]
        public int SkillAbnormalBehaviourActionId { get; set; } // 0x10

        [Key(1)]
        public int Value { get; set; } // 0x14
    }
}
