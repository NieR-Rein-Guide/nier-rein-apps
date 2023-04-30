using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_cooltime_behaviour")]
    public class EntityMSkillCooltimeBehaviour
    {
        [Key(0)]
        public int SkillCooltimeBehaviourId { get; set; } // 0x10

        [Key(1)]
        public SkillCooltimeBehaviourType SkillCooltimeBehaviourType { get; set; } // 0x14

        [Key(2)]
        public int SkillCooltimeBehaviourActionId { get; set; } // 0x18
    }
}
