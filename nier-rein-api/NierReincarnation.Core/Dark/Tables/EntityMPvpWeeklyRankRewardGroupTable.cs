using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPvpWeeklyRankRewardGroupTable : TableBase<EntityMPvpWeeklyRankRewardGroup>
    {
        private readonly Func<EntityMPvpWeeklyRankRewardGroup, (int,int)> primaryIndexSelector;

        public EntityMPvpWeeklyRankRewardGroupTable(EntityMPvpWeeklyRankRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.PvpWeeklyRankRewardGroupId,element.PvpRewardId);
        }
        
        public RangeView<EntityMPvpWeeklyRankRewardGroup> FindRangeByPvpWeeklyRankRewardGroupIdAndPvpRewardId(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, min, max, ascendant); }

    }
}
