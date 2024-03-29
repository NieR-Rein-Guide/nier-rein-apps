using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMShopItemContentPossessionTable : TableBase<EntityMShopItemContentPossession>
{
    private readonly Func<EntityMShopItemContentPossession, (int, PossessionType, int)> primaryIndexSelector;

    public EntityMShopItemContentPossessionTable(EntityMShopItemContentPossession[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.ShopItemId, element.PossessionType, element.PossessionId);
    }
}
