using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour_action_abnormal_resistance")]
    public class EntityMSkillAbnormalBehaviourActionAbnormalResistance
    {
        [Key(0)]
        public int SkillAbnormalBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public AbnormalResistancePolarityType AbnormalResistancePolarityType { get; set; } // 0x14
        [Key(2)]
        public int AbnormalResistanceSkillAbnormalTypeId { get; set; } // 0x18
        [Key(3)]
        public int BlockProbabilityPermil { get; set; } // 0x1C
    }
}