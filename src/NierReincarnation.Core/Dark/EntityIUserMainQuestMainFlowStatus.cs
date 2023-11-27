using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserMainQuestMainFlowStatus))]
public class EntityIUserMainQuestMainFlowStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CurrentMainQuestRouteId { get; set; }

    [Key(2)]
    public int CurrentQuestSceneId { get; set; }

    [Key(3)]
    public int HeadQuestSceneId { get; set; }

    [Key(4)]
    public bool IsReachedLastQuestScene { get; set; }

    [Key(5)]
    public long LatestVersion { get; set; }
}
