using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserShopReplaceable))]
public class EntityIUserShopReplaceable
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int LineupUpdateCount { get; set; }

    [Key(2)]
    public long LatestLineupUpdateDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
