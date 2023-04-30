using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_casttime_behaviour_group")]
    public class EntityMSkillCasttimeBehaviourGroup
    {
        [Key(0)]
        public int SkillCasttimeBehaviourGroupId { get; set; } // 0x10

        [Key(1)]
        public int SkillCasttimeBehaviourIndex { get; set; } // 0x14

        [Key(2)]
        public int SkillCasttimeBehaviourId { get; set; } // 0x18
    }
}
