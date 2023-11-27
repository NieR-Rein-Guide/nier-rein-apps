using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserDokan))]
public class EntityIUserDokan
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int DokanId { get; set; }

    [Key(2)]
    public long DisplayDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
