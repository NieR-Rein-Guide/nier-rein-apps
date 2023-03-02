using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBigHuntScoreRewardGroupTable : TableBase<EntityMBigHuntScoreRewardGroup>
    {
        private readonly Func<EntityMBigHuntScoreRewardGroup, (int,long)> primaryIndexSelector;

        public EntityMBigHuntScoreRewardGroupTable(EntityMBigHuntScoreRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BigHuntScoreRewardGroupId,element.NecessaryScore);
        }
        
    }
}
