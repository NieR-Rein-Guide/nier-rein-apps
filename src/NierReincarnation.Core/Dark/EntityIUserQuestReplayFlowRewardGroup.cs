using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserQuestReplayFlowRewardGroup))]
public class EntityIUserQuestReplayFlowRewardGroup
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int QuestReplayFlowRewardGroupId { get; set; }

    [Key(2)]
    public long ReceiveDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
