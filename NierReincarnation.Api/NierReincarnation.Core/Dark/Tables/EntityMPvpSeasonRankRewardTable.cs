using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPvpSeasonRankRewardTable : TableBase<EntityMPvpSeasonRankReward>
    {
        private readonly Func<EntityMPvpSeasonRankReward, int> primaryIndexSelector;

        public EntityMPvpSeasonRankRewardTable(EntityMPvpSeasonRankReward[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.RankLowerLimit;
        }
    }
}
