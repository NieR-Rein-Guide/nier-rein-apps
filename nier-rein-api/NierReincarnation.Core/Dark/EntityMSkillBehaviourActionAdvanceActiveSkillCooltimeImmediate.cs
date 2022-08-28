using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_advance_active_skill_cooltime_immediate")]
    public class EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediate
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int SkillCooltimeAdvanceType { get; set; } // 0x14
        [Key(2)]
        public int ActiveSkillType { get; set; } // 0x18
        [Key(3)]
        public int AdvanceValue { get; set; } // 0x1C
    }
}