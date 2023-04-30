using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMExploreGradeScoreTable : TableBase<EntityMExploreGradeScore>
    {
        private readonly Func<EntityMExploreGradeScore, (int, int)> primaryIndexSelector;

        public EntityMExploreGradeScoreTable(EntityMExploreGradeScore[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.ExploreId, element.NecessaryScore);
        }

        public EntityMExploreGradeScore FindClosestByExploreIdAndNecessaryScore(ValueTuple<int, int> key, bool selectLower = true) =>
            FindUniqueClosestCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key, selectLower);
    }
}
