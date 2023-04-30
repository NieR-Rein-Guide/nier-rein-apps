using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_lifetime_behaviour_activate_count")]
    public class EntityMSkillAbnormalLifetimeBehaviourActivateCount
    {
        [Key(0)]
        public int SkillAbnormalLifetimeBehaviourId { get; set; } // 0x10

        [Key(1)]
        public int ActivateCount { get; set; } // 0x14

        [Key(2)]
        public int AbnormalBehaviourIndex { get; set; } // 0x18
    }
}
