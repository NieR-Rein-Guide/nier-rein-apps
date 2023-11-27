using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserShopReplaceableLineup))]
public class EntityIUserShopReplaceableLineup
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int SlotNumber { get; set; }

    [Key(2)]
    public int ShopItemId { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
