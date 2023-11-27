using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestReplayFlowRewardGroup))]
public class EntityMQuestReplayFlowRewardGroup
{
    [Key(0)]
    public int QuestReplayFlowRewardGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public PossessionType PossessionType { get; set; }

    [Key(3)]
    public int PossessionId { get; set; }

    [Key(4)]
    public int Count { get; set; }
}
