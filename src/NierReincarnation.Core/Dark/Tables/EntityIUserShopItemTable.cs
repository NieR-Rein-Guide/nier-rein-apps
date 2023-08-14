using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserShopItemTable : TableBase<EntityIUserShopItem>
{
    private readonly Func<EntityIUserShopItem, (long, int)> primaryIndexSelector;

    public EntityIUserShopItemTable(EntityIUserShopItem[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.ShopItemId);
    }

    public EntityIUserShopItem FindByUserIdAndShopItemId((long, int) key) => FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key);
}
