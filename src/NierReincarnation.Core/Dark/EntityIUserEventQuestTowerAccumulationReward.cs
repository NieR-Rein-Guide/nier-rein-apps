using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserEventQuestTowerAccumulationReward))]
public class EntityIUserEventQuestTowerAccumulationReward
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int EventQuestChapterId { get; set; }

    [Key(2)]
    public int LatestRewardReceiveQuestMissionClearCount { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
