using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_cooltime_behaviour_group")]
    public class EntityMSkillCooltimeBehaviourGroup
    {
        [Key(0)]
        public int SkillCooltimeBehaviourGroupId { get; set; } // 0x10
        [Key(1)]
        public int SkillCooltimeBehaviourId { get; set; } // 0x14
    }
}