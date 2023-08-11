using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_skill_behaviour_hit_damage_configuration")]
    public class EntityMBattleSkillBehaviourHitDamageConfiguration
    {
        [Key(0)]
        public SkillCategoryType SkillCategoryType { get; set; }

        [Key(1)]
        public int HitCount { get; set; }

        [Key(2)]
        public int HitIndexLowerLimit { get; set; }

        [Key(3)]
        public int DamageCoefficientValuePermil { get; set; }
    }
}
