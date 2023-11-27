using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeLotteryEffectReleaseSchedule))]
public class EntityMCostumeLotteryEffectReleaseSchedule
{
    [Key(0)]
    public int CostumeLotteryEffectReleaseScheduleId { get; set; }

    [Key(1)]
    public long ReleaseDatetime { get; set; }
}
