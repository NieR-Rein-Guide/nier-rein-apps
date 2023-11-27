using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillCooltimeBehaviourOnSkillDamage))]
public class EntityMSkillCooltimeBehaviourOnSkillDamage
{
    [Key(0)]
    public int SkillCooltimeBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillCooltimeAdvanceValueCalculationId { get; set; }
}
