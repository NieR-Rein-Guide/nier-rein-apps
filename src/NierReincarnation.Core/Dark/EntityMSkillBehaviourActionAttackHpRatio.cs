using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionAttackHpRatio))]
public class EntityMSkillBehaviourActionAttackHpRatio
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillPowerCalculationId { get; set; }
}
