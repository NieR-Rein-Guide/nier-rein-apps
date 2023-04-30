using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_casttime")]
    public class EntityMSkillCasttime
    {
        [Key(0)]
        public int SkillCasttimeId { get; set; } // 0x10

        [Key(1)]
        public int SkillCasttimeValue { get; set; } // 0x14

        [Key(2)]
        public int SkillCasttimeBehaviourGroupId { get; set; } // 0x18
    }
}
