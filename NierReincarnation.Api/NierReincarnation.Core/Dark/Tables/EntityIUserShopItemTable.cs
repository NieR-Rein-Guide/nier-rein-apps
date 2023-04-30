using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserShopItemTable : TableBase<EntityIUserShopItem>
    {
        private readonly Func<EntityIUserShopItem, (long, int)> primaryIndexSelector;

        public EntityIUserShopItemTable(EntityIUserShopItem[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.ShopItemId);
        }
    }
}
