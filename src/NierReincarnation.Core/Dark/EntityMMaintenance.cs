using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMaintenance))]
public class EntityMMaintenance
{
    [Key(0)]
    public int MaintenanceId { get; set; }

    [Key(1)]
    public long StartDatetime { get; set; }

    [Key(2)]
    public long EndDatetime { get; set; }

    [Key(3)]
    public int MaintenanceGroupId { get; set; }
}
