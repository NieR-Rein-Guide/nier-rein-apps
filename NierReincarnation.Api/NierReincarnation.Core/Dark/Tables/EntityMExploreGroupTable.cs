using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMExploreGroupTable : TableBase<EntityMExploreGroup>
    {
        private readonly Func<EntityMExploreGroup, (int, DifficultyType)> primaryIndexSelector;
        private readonly Func<EntityMExploreGroup, int> secondaryIndexSelector;

        public EntityMExploreGroupTable(EntityMExploreGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.ExploreGroupId,element.DifficultyType);
            secondaryIndexSelector = element => element.ExploreId;
        }
        
        public EntityMExploreGroup FindByExploreGroupIdAndDifficultyType(ValueTuple<int, DifficultyType> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int, DifficultyType)>.Default, key); }

	
        public RangeView<EntityMExploreGroup> FindByExploreId(int key) { return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key); }

    }
}
