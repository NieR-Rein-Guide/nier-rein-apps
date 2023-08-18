using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_lottery_effect_target_ability")]
public class EntityMCostumeLotteryEffectTargetAbility
{
    [Key(0)]
    public int CostumeLotteryEffectTargetAbilityId { get; set; }

    [Key(1)]
    public int AbilityId { get; set; }

    [Key(2)]
    public int AbilityLevel { get; set; }
}
