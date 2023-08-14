using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_shop_item_content_possession")]
public class EntityMShopItemContentPossession
{
    [Key(0)]
    public int ShopItemId { get; set; }

    [Key(1)]
    public PossessionType PossessionType { get; set; }

    [Key(2)]
    public int PossessionId { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }

    [Key(4)]
    public int Count { get; set; }
}
