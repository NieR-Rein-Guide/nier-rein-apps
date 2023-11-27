using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeLotteryEffectTargetAbility))]
public class EntityMCostumeLotteryEffectTargetAbility
{
    [Key(0)]
    public int CostumeLotteryEffectTargetAbilityId { get; set; }

    [Key(1)]
    public int AbilityId { get; set; }

    [Key(2)]
    public int AbilityLevel { get; set; }
}
