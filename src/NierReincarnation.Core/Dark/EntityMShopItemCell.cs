using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMShopItemCell))]
public class EntityMShopItemCell
{
    [Key(0)]
    public int ShopItemCellId { get; set; }

    [Key(1)]
    public int StepNumber { get; set; }

    [Key(2)]
    public int ShopItemId { get; set; }
}
