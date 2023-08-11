using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_attribute_damage_coefficient_group")]
    public class EntityMBattleAttributeDamageCoefficientGroup
    {
        [Key(0)]
        public int AttributeDamageCoefficientGroupId { get; set; }

        [Key(1)]
        public int SkillExecutorAttributeType { get; set; }

        [Key(2)]
        public int SkillTargetAttributeType { get; set; }

        [Key(3)]
        public AttributeCompatibilityType AttributeCompatibilityType { get; set; }

        [Key(4)]
        public int DamageCoefficientPermil { get; set; }
    }
}
