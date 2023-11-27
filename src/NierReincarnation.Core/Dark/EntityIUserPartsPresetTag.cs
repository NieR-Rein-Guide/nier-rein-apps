using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserPartsPresetTag))]
public class EntityIUserPartsPresetTag
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int UserPartsPresetTagNumber { get; set; }

    [Key(2)]
    public string Name { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
