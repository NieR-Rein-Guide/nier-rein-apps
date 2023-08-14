using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_shop_item_cell")]
public class EntityMShopItemCell
{
    [Key(0)]
    public int ShopItemCellId { get; set; }

    [Key(1)]
    public int StepNumber { get; set; }

    [Key(2)]
    public int ShopItemId { get; set; }
}
