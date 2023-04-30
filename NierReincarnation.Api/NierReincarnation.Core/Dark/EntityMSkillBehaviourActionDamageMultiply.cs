using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_damage_multiply")]
    public class EntityMSkillBehaviourActionDamageMultiply
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10

        [Key(1)]
        public DamageMultiplyDetailType DamageMultiplyDetailType { get; set; } // 0x14

        [Key(2)]
        public int SkillDamageMultiplyDetailId { get; set; } // 0x18

        [Key(3)]
        public DamageMultiplyTargetType DamageMultiplyTargetType { get; set; } // 0x1C
    }
}
