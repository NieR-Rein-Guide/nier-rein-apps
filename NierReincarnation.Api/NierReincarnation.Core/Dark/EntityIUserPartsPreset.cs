using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_parts_preset")]
public class EntityIUserPartsPreset
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int UserPartsPresetNumber { get; set; }

    [Key(2)]
    public string UserPartsUuid01 { get; set; }

    [Key(3)]
    public string UserPartsUuid02 { get; set; }

    [Key(4)]
    public string UserPartsUuid03 { get; set; }

    [Key(5)]
    public string Name { get; set; }

    [Key(6)]
    public int UserPartsPresetTagNumber { get; set; }

    [Key(7)]
    public long LatestVersion { get; set; }
}
