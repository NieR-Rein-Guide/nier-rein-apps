using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour_group")]
    public class EntityMSkillAbnormalBehaviourGroup
    {
        [Key(0)]
        public int SkillAbnormalBehaviourGroupId { get; set; }

        [Key(1)]
        public int AbnormalBehaviourIndex { get; set; }

        [Key(2)]
        public int SkillAbnormalBehaviourId { get; set; }
    }
}
