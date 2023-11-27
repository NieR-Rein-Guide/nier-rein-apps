using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionHpRatioDamage))]
public class EntityMSkillBehaviourActionHpRatioDamage
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int CalculateDenominatorType { get; set; }

    [Key(2)]
    public int DamageRatioPermil { get; set; }
}
