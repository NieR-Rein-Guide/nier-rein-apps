using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_parts_preset_tag")]
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
