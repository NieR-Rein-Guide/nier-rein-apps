using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserFacebook))]
public class EntityIUserFacebook
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public long FacebookId { get; set; }

    [Key(2)]
    public long LatestVersion { get; set; }
}
