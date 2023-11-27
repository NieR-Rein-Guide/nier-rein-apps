using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserLimitedOpen))]
public class EntityIUserLimitedOpen
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public LimitedOpenTargetType LimitedOpenTargetType { get; set; }

    [Key(2)]
    public int TargetId { get; set; }

    [Key(3)]
    public long OpenDatetime { get; set; }

    [Key(4)]
    public long CloseDatetime { get; set; }

    [Key(5)]
    public long LatestVersion { get; set; }
}
