using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserMainQuestSeasonRoute))]
public class EntityIUserMainQuestSeasonRoute
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int MainQuestSeasonId { get; set; }

    [Key(2)]
    public int MainQuestRouteId { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
