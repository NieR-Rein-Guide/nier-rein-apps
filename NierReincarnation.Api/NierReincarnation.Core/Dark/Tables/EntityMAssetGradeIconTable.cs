using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMAssetGradeIconTable : TableBase<EntityMAssetGradeIcon>
    {
        private readonly Func<EntityMAssetGradeIcon, int> primaryIndexSelector;

        public EntityMAssetGradeIconTable(EntityMAssetGradeIcon[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.AssetGradeIconId;
        }

        public EntityMAssetGradeIcon FindByAssetGradeIconId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
