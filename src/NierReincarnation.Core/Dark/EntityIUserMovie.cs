using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserMovie))]
public class EntityIUserMovie
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int MovieId { get; set; }

    [Key(2)]
    public long LatestViewedDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
