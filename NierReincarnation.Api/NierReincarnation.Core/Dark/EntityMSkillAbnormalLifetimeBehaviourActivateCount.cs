using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_lifetime_behaviour_activate_count")]
    public class EntityMSkillAbnormalLifetimeBehaviourActivateCount
    {
        [Key(0)]
        public int SkillAbnormalLifetimeBehaviourId { get; set; }

        [Key(1)]
        public int ActivateCount { get; set; }

        [Key(2)]
        public int AbnormalBehaviourIndex { get; set; }
    }
}
