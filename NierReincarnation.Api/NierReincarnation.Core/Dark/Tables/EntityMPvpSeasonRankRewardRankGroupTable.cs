using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPvpSeasonRankRewardRankGroupTable : TableBase<EntityMPvpSeasonRankRewardRankGroup>
    {
        private readonly Func<EntityMPvpSeasonRankRewardRankGroup, (int, int)> primaryIndexSelector;

        public EntityMPvpSeasonRankRewardRankGroupTable(EntityMPvpSeasonRankRewardRankGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.PvpSeasonRankRewardRankGroupId, element.RankLowerLimit);
        }

        public RangeView<EntityMPvpSeasonRankRewardRankGroup> FindRangeByPvpSeasonRankRewardRankGroupIdAndRankLowerLimit(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
            FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
    }
}
