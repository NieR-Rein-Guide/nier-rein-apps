using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour_action_buff_resistance")]
    public class EntityMSkillAbnormalBehaviourActionBuffResistance
    {
        [Key(0)]
        public int SkillAbnormalBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int BuffResistanceType { get; set; } // 0x14
        [Key(2)]
        public int BuffResistanceStatusKindType { get; set; } // 0x18
        [Key(3)]
        public int BlockProbabilityPermil { get; set; } // 0x1C
    }
}