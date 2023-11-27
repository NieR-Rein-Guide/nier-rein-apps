using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserPartsGroupNote))]
public class EntityIUserPartsGroupNote
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int PartsGroupId { get; set; }

    [Key(2)]
    public long FirstAcquisitionDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
