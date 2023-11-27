using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMShopItemAdditionalContent))]
public class EntityMShopItemAdditionalContent
{
    [Key(0)]
    public int ShopItemAdditionalContentId { get; set; }

    [Key(1)]
    public PossessionType PossessionType { get; set; }

    [Key(2)]
    public int PossessionId { get; set; }

    [Key(3)]
    public int Count { get; set; }
}
