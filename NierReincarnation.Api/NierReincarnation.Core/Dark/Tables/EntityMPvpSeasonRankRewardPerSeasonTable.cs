using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPvpSeasonRankRewardPerSeasonTable : TableBase<EntityMPvpSeasonRankRewardPerSeason>
{
    private readonly Func<EntityMPvpSeasonRankRewardPerSeason, (int, int)> primaryIndexSelector;

    public EntityMPvpSeasonRankRewardPerSeasonTable(EntityMPvpSeasonRankRewardPerSeason[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.RankLowerLimit, element.PvpSeasonId);
    }
}
