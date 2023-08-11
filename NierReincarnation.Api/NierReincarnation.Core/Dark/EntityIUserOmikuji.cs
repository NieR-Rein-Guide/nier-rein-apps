using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_omikuji")]
public class EntityIUserOmikuji
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int OmikujiId { get; set; }

    [Key(2)]
    public long LatestDrawDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
