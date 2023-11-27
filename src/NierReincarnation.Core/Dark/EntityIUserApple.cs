using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserApple))]
public class EntityIUserApple
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string AppleId { get; set; }

    [Key(2)]
    public long LatestVersion { get; set; }
}
