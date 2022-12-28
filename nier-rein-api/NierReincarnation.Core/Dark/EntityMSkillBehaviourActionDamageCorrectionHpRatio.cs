using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_damage_correction_hp_ratio")]
    public class EntityMSkillBehaviourActionDamageCorrectionHpRatio
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int CorrectionMaxValuePermil { get; set; } // 0x14
        [Key(2)]
        public DamageCorrectionHpRatioType DamageCorrectionHpRatioType { get; set; } // 0x18
        [Key(3)]
        public int ActivationThresholdHpRatioPermil { get; set; } // 0x1C
    }
}