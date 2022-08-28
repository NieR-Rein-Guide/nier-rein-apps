using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_hp_ratio_damage")]
    public class EntityMSkillBehaviourActionHpRatioDamage
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int CalculateDenominatorType { get; set; } // 0x14
        [Key(2)]
        public int DamageRatioPermil { get; set; } // 0x18
    }
}