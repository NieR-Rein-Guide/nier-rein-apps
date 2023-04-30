using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMTipGroupBackgroundAssetTable : TableBase<EntityMTipGroupBackgroundAsset>
    {
        private readonly Func<EntityMTipGroupBackgroundAsset, (int, string)> primaryIndexSelector;

        public EntityMTipGroupBackgroundAssetTable(EntityMTipGroupBackgroundAsset[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.TipGroupId, element.BackgroundAssetName);
        }
    }
}
