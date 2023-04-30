using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMShopItemUserLevelConditionTable : TableBase<EntityMShopItemUserLevelCondition>
    {
        private readonly Func<EntityMShopItemUserLevelCondition, int> primaryIndexSelector;

        public EntityMShopItemUserLevelConditionTable(EntityMShopItemUserLevelCondition[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ShopItemId;
        }
    }
}
