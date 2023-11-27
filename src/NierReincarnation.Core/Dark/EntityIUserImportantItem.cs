using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserImportantItem))]
public class EntityIUserImportantItem
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int ImportantItemId { get; set; }

    [Key(2)]
    public int Count { get; set; }

    [Key(3)]
    public long FirstAcquisitionDatetime { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
