using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMAssetBackgroundTable : TableBase<EntityMAssetBackground>
    {
        private readonly Func<EntityMAssetBackground, int> primaryIndexSelector;

        public EntityMAssetBackgroundTable(EntityMAssetBackground[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.AssetBackgroundId;
        }
        
        public EntityMAssetBackground FindByAssetBackgroundId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
