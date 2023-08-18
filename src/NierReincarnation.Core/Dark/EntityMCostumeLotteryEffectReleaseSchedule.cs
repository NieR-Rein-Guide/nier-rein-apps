using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_lottery_effect_release_schedule")]
public class EntityMCostumeLotteryEffectReleaseSchedule
{
    [Key(0)]
    public int CostumeLotteryEffectReleaseScheduleId { get; set; }

    [Key(1)]
    public long ReleaseDatetime { get; set; }
}
