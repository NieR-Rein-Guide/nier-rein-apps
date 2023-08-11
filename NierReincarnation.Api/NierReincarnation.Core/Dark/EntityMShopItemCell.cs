using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_shop_item_cell")]
public class EntityMShopItemCell
{
    [Key(0)] // RVA: 0x1DDFC18 Offset: 0x1DDFC18 VA: 0x1DDFC18
    public int ShopItemCellId { get; set; }

    [Key(1)] // RVA: 0x1DDFC58 Offset: 0x1DDFC58 VA: 0x1DDFC58
    public int StepNumber { get; set; }

    [Key(2)] // RVA: 0x1DDFC98 Offset: 0x1DDFC98 VA: 0x1DDFC98
    public int ShopItemId { get; set; }
}
