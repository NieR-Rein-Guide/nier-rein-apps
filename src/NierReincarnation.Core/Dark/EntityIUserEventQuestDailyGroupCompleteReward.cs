using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserEventQuestDailyGroupCompleteReward))]
public class EntityIUserEventQuestDailyGroupCompleteReward
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int LastRewardReceiveEventQuestDailyGroupId { get; set; }

    [Key(2)]
    public long LastRewardReceiveDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
