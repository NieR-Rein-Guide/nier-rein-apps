using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMTipBackgroundAssetTable : TableBase<EntityMTipBackgroundAsset>
    {
        private readonly Func<EntityMTipBackgroundAsset, int> primaryIndexSelector;

        public EntityMTipBackgroundAssetTable(EntityMTipBackgroundAsset[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.TipBackgroundAssetId;
        }

        public EntityMTipBackgroundAsset FindByTipBackgroundAssetId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
