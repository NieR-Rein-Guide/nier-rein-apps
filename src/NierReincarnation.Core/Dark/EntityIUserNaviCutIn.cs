using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserNaviCutIn))]
public class EntityIUserNaviCutIn
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int NaviCutInId { get; set; }

    [Key(2)]
    public long PlayDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
