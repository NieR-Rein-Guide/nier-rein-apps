using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMShopReplaceableGemTable : TableBase<EntityMShopReplaceableGem>
    {
        private readonly Func<EntityMShopReplaceableGem, int> primaryIndexSelector;

        public EntityMShopReplaceableGemTable(EntityMShopReplaceableGem[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.LineupUpdateCountLowerLimit;
        }
        
    }
}
