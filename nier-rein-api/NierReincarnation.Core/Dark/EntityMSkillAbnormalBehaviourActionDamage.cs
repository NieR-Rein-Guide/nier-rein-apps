using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour_action_damage")]
    public class EntityMSkillAbnormalBehaviourActionDamage
    {
        [Key(0)]
        public int SkillAbnormalBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int AbnormalBehaviourDamageType { get; set; } // 0x14
        [Key(2)]
        public int Power { get; set; } // 0x18
    }
}