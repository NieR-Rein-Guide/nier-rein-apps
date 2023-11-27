using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleAttributeDamageCoefficientGroup))]
public class EntityMBattleAttributeDamageCoefficientGroup
{
    [Key(0)]
    public int AttributeDamageCoefficientGroupId { get; set; }

    [Key(1)]
    public AttributeType SkillExecutorAttributeType { get; set; }

    [Key(2)]
    public AttributeType SkillTargetAttributeType { get; set; }

    [Key(3)]
    public AttributeCompatibilityType AttributeCompatibilityType { get; set; }

    [Key(4)]
    public int DamageCoefficientPermil { get; set; }
}
