using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_shop_item_cell_term")]
public class EntityMShopItemCellTerm
{
    [Key(0)]
    public int ShopItemCellTermId { get; set; }

    [Key(1)]
    public long StartDatetime { get; set; }

    [Key(2)]
    public long EndDatetime { get; set; }
}
