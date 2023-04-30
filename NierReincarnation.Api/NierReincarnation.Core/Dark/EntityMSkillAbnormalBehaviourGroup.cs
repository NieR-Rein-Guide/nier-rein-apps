using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour_group")]
    public class EntityMSkillAbnormalBehaviourGroup
    {
        [Key(0)]
        public int SkillAbnormalBehaviourGroupId { get; set; } // 0x10

        [Key(1)]
        public int AbnormalBehaviourIndex { get; set; } // 0x14

        [Key(2)]
        public int SkillAbnormalBehaviourId { get; set; } // 0x18
    }
}
