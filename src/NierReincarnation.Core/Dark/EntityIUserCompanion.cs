using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserCompanion))]
public class EntityIUserCompanion
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserCompanionUuid { get; set; }

    [Key(2)]
    public int CompanionId { get; set; }

    [Key(3)]
    public int HeadupDisplayViewId { get; set; }

    [Key(4)]
    public int Level { get; set; }

    [Key(5)]
    public long AcquisitionDatetime { get; set; }

    [Key(6)]
    public long LatestVersion { get; set; }
}
