using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMExploreGroupTable : TableBase<EntityMExploreGroup>
    {
        private readonly Func<EntityMExploreGroup, (int,int)> primaryIndexSelector;
        private readonly Func<EntityMExploreGroup, int> secondaryIndexSelector;

        public EntityMExploreGroupTable(EntityMExploreGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.ExploreGroupId,element.DifficultyType);
            secondaryIndexSelector = element => element.ExploreId;
        }
        
        public EntityMExploreGroup FindByExploreGroupIdAndDifficultyType(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

	
        public RangeView<EntityMExploreGroup> FindByExploreId(int key) { return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key); }

    }
}
