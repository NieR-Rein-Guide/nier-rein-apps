using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_casttime_behaviour")]
    public class EntityMSkillCasttimeBehaviour
    {
        [Key(0)]
        public int SkillCasttimeBehaviourId { get; set; } // 0x10
        [Key(1)]
        public SkillCasttimeBehaviourType SkillCasttimeBehaviourType { get; set; } // 0x14
        [Key(2)]
        public int SkillCasttimeBehaviourActionId { get; set; } // 0x18
    }
}