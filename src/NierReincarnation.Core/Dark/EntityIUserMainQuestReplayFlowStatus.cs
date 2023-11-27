using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserMainQuestReplayFlowStatus))]
public class EntityIUserMainQuestReplayFlowStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CurrentHeadQuestSceneId { get; set; }

    [Key(2)]
    public int CurrentQuestSceneId { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
