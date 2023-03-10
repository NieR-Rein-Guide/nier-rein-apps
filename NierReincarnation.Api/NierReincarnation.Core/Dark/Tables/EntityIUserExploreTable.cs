using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserExploreTable : TableBase<EntityIUserExplore>
    {
        private readonly Func<EntityIUserExplore, long> primaryIndexSelector;

        public EntityIUserExploreTable(EntityIUserExplore[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }

        public EntityIUserExplore FindByUserId(long key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key); }

        public bool TryFindByUserId(long key, out EntityIUserExplore result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key, out result); }
    }
}