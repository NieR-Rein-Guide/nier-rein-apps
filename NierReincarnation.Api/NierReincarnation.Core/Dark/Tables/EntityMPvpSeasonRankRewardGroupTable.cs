using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPvpSeasonRankRewardGroupTable : TableBase<EntityMPvpSeasonRankRewardGroup>
{
    private readonly Func<EntityMPvpSeasonRankRewardGroup, (int, int)> primaryIndexSelector;

    public EntityMPvpSeasonRankRewardGroupTable(EntityMPvpSeasonRankRewardGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.PvpSeasonRankRewardGroupId, element.PvpRewardId);
    }

    public RangeView<EntityMPvpSeasonRankRewardGroup> FindRangeByPvpSeasonRankRewardGroupIdAndPvpRewardId(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
