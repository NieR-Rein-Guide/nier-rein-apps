using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMShopDisplayPriceTable : TableBase<EntityMShopDisplayPrice>
{
    private readonly Func<EntityMShopDisplayPrice, (PriceType, int)> primaryIndexSelector;

    public EntityMShopDisplayPriceTable(EntityMShopDisplayPrice[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.PriceType, element.PriceId);
    }

    public EntityMShopDisplayPrice FindByPriceTypeAndPriceId(ValueTuple<PriceType, int> key) => FindUniqueCore(data, primaryIndexSelector, Comparer<(PriceType, int)>.Default, key);
}
