using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_attack_ignore_vitality")]
    public class EntityMSkillBehaviourActionAttackIgnoreVitality
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10

        [Key(1)]
        public int SkillPower { get; set; } // 0x14
    }
}
