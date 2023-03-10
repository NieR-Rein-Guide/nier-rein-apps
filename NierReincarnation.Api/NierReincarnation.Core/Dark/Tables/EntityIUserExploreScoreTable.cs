using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserExploreScoreTable : TableBase<EntityIUserExploreScore>
    {
        private readonly Func<EntityIUserExploreScore, (long, int)> primaryIndexSelector;

        public EntityIUserExploreScoreTable(EntityIUserExploreScore[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.ExploreId);
        }

        public EntityIUserExploreScore FindByUserIdAndExploreId(ValueTuple<long, int> key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key); }
    }
}
