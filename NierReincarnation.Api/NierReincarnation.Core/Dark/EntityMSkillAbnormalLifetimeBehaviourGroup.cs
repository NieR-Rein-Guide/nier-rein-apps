using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_lifetime_behaviour_group")]
    public class EntityMSkillAbnormalLifetimeBehaviourGroup
    {
        [Key(0)]
        public int SkillAbnormalLifetimeBehaviourGroupId { get; set; } // 0x10

        [Key(1)]
        public int AbnormalLifetimeBehaviourIndex { get; set; } // 0x14

        [Key(2)]
        public AbnormalLifetimeMethodType AbnormalLifetimeMethodType { get; set; } // 0x18

        [Key(3)]
        public int SkillAbnormalLifetimeBehaviourId { get; set; } // 0x1C
    }
}
