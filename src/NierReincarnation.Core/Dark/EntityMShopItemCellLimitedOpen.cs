using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMShopItemCellLimitedOpen))]
public class EntityMShopItemCellLimitedOpen
{
    [Key(0)]
    public int ShopItemCellId { get; set; }

    [Key(1)]
    public int LimitedOpenId { get; set; }
}
