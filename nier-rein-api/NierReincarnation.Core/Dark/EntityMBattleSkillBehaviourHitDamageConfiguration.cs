using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_skill_behaviour_hit_damage_configuration")]
    public class EntityMBattleSkillBehaviourHitDamageConfiguration
    {
        [Key(0)]
        public int SkillCategoryType { get; set; } // 0x10
        [Key(1)]
        public int HitCount { get; set; } // 0x14
        [Key(2)]
        public int HitIndexLowerLimit { get; set; } // 0x18
        [Key(3)]
        public int DamageCoefficientValuePermil { get; set; } // 0x1C
    }
}