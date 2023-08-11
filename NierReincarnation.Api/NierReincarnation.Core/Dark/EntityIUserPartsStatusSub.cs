using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_parts_status_sub")]
public class EntityIUserPartsStatusSub
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserPartsUuid { get; set; }

    [Key(2)]
    public int StatusIndex { get; set; }

    [Key(3)]
    public int PartsStatusSubLotteryId { get; set; }

    [Key(4)]
    public int Level { get; set; }

    [Key(5)]
    public StatusKindType StatusKindType { get; set; }

    [Key(6)]
    public StatusCalculationType StatusCalculationType { get; set; }

    [Key(7)]
    public int StatusChangeValue { get; set; }

    [Key(8)]
    public long LatestVersion { get; set; }
}
