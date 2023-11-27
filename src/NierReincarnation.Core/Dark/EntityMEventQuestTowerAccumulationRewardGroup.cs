using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestTowerAccumulationRewardGroup))]
public class EntityMEventQuestTowerAccumulationRewardGroup
{
    [Key(0)]
    public int EventQuestTowerAccumulationRewardGroupId { get; set; }

    [Key(1)]
    public int QuestMissionClearCount { get; set; }

    [Key(2)]
    public int EventQuestTowerRewardGroupId { get; set; }
}
