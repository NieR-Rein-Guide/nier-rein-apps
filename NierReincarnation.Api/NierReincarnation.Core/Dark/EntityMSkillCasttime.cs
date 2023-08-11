using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_casttime")]
    public class EntityMSkillCasttime
    {
        [Key(0)]
        public int SkillCasttimeId { get; set; }

        [Key(1)]
        public int SkillCasttimeValue { get; set; }

        [Key(2)]
        public int SkillCasttimeBehaviourGroupId { get; set; }
    }
}
