using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_abnormal")]
    public class EntityMSkillBehaviourActionAbnormal
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int SkillBehaviourAbnormalId { get; set; } // 0x14
    }
}