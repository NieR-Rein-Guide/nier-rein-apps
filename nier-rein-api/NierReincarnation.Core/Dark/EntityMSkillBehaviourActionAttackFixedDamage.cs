using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_attack_fixed_damage")]
    public class EntityMSkillBehaviourActionAttackFixedDamage
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int DamageValue { get; set; } // 0x14
        [Key(2)]
        public bool ForceDamage { get; set; } // 0x18
    }
}