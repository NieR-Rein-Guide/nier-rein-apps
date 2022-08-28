using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour_action_default_skill_lottery")]
    public class EntityMSkillAbnormalBehaviourActionDefaultSkillLottery
    {
        [Key(0)]
        public int SkillAbnormalBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int TargetCountLower { get; set; } // 0x14
        [Key(2)]
        public int TargetCountUpper { get; set; } // 0x18
        [Key(3)]
        public int ValuePermil { get; set; } // 0x1C
        [Key(4)]
        public int CalculationType { get; set; } // 0x20
    }
}