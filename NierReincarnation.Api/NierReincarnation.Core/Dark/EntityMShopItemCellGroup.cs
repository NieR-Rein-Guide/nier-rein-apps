using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_shop_item_cell_group")]
public class EntityMShopItemCellGroup
{
    [Key(0)]
    public int ShopItemCellGroupId { get; set; }

    [Key(1)]
    public int ShopItemCellId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }

    [Key(3)]
    public int ShopItemCellTermId { get; set; }
}
