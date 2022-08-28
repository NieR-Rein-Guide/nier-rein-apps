using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMExploreGradeAssetTable : TableBase<EntityMExploreGradeAsset>
    {
        private readonly Func<EntityMExploreGradeAsset, int> primaryIndexSelector;

        public EntityMExploreGradeAssetTable(EntityMExploreGradeAsset[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ExploreGradeId;
        }
        
        public EntityMExploreGradeAsset FindByExploreGradeId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
