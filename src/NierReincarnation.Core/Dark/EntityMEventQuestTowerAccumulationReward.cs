using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestTowerAccumulationReward))]
public class EntityMEventQuestTowerAccumulationReward
{
    [Key(0)]
    public int EventQuestChapterId { get; set; }

    [Key(1)]
    public int EventQuestTowerAccumulationRewardGroupId { get; set; }
}
