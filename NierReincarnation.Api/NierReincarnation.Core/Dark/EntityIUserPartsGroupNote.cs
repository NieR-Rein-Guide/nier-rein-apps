using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_parts_group_note")]
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
