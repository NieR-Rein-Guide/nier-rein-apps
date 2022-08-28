using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour_action_attribute_damage_correction")]
    public class EntityMSkillAbnormalBehaviourActionAttributeDamageCorrection
    {
        [Key(0)]
        public int SkillAbnormalBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int AttributeType { get; set; } // 0x14
        [Key(2)]
        public int CorrectionTargetDamageType { get; set; } // 0x18
        [Key(3)]
        public int CorrectionValuePermil { get; set; } // 0x1C
        [Key(4)]
        public int DamageCorrectionOverlapType { get; set; } // 0x20
        [Key(5)]
        public bool IsExcepting { get; set; } // 0x24
    }
}