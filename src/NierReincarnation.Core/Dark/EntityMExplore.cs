using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_explore")]
public class EntityMExplore
{
    [Key(0)]
    public int ExploreId { get; set; }

    [Key(1)]
    public int ExploreUnlockConditionId { get; set; }

    [Key(2)]
    public long StartDatetime { get; set; }

    [Key(3)]
    public int ConsumeItemCount { get; set; }

    [Key(4)]
    public int RewardLotteryCount { get; set; }
}
