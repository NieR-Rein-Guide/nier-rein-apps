using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_attack_vitality")]
    public class EntityMSkillBehaviourActionAttackVitality
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10

        [Key(1)]
        public int SkillPower { get; set; } // 0x14

        [Key(2)]
        public int AttackWeight { get; set; } // 0x18

        [Key(3)]
        public int VitalityWeight { get; set; } // 0x1C
    }
}
