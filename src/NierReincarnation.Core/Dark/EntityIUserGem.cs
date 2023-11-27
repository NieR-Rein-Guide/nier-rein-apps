using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserGem))]
public class EntityIUserGem
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int PaidGem { get; set; }

    [Key(2)]
    public int FreeGem { get; set; }
}
