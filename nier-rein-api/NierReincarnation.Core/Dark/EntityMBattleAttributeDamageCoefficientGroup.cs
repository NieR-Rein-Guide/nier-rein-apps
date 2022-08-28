using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_attribute_damage_coefficient_group")]
    public class EntityMBattleAttributeDamageCoefficientGroup
    {
        [Key(0)]
        public int AttributeDamageCoefficientGroupId { get; set; } // 0x10
        [Key(1)]
        public int SkillExecutorAttributeType { get; set; } // 0x14
        [Key(2)]
        public int SkillTargetAttributeType { get; set; } // 0x18
        [Key(3)]
        public int AttributeCompatibilityType { get; set; } // 0x1C
        [Key(4)]
        public int DamageCoefficientPermil { get; set; } // 0x20
    }
}