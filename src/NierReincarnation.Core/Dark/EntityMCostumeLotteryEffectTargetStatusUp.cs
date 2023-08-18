using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_lottery_effect_target_status_up")]
public class EntityMCostumeLotteryEffectTargetStatusUp
{
    [Key(0)]
    public int CostumeLotteryEffectTargetStatusUpId { get; set; }

    [Key(1)]
    public StatusKindType StatusKindType { get; set; }

    [Key(2)]
    public StatusCalculationType StatusCalculationType { get; set; }

    [Key(3)]
    public int EffectValue { get; set; }
}
