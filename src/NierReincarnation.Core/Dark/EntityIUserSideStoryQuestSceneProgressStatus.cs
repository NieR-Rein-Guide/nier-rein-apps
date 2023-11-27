using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserSideStoryQuestSceneProgressStatus))]
public class EntityIUserSideStoryQuestSceneProgressStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CurrentSideStoryQuestId { get; set; }

    [Key(2)]
    public int CurrentSideStoryQuestSceneId { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
