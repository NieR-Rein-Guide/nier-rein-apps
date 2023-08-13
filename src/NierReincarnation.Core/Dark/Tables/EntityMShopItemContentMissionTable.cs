using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMShopItemContentMissionTable : TableBase<EntityMShopItemContentMission>
{
    private readonly Func<EntityMShopItemContentMission, int> primaryIndexSelector;

    public EntityMShopItemContentMissionTable(EntityMShopItemContentMission[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ShopItemId;
    }

    public EntityMShopItemContentMission FindByShopItemId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
