using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_parts")]
public class EntityIUserParts
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserPartsUuid { get; set; }

    [Key(2)]
    public int PartsId { get; set; }

    [Key(3)]
    public int Level { get; set; }

    [Key(4)]
    public int PartsStatusMainId { get; set; }

    [Key(5)]
    public bool IsProtected { get; set; }

    [Key(6)]
    public long AcquisitionDatetime { get; set; }

    [Key(7)]
    public long LatestVersion { get; set; }
}
