using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_recovery")]
    public class EntityMSkillBehaviourActionRecovery
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10

        [Key(1)]
        public int SkillPower { get; set; } // 0x14

        [Key(2)]
        public int FixedRecoveryPoint { get; set; } // 0x18

        [Key(3)]
        public int HpRatioRecoveryPointPermil { get; set; } // 0x1C

        [Key(4)]
        public int RecoveryPointMinValue { get; set; } // 0x20

        [Key(5)]
        public int RecoveryPointMaxValue { get; set; } // 0x24
    }
}
