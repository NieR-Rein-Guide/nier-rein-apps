using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPvpGradeOneMatchRewardTable : TableBase<EntityMPvpGradeOneMatchReward>
    {
        private readonly Func<EntityMPvpGradeOneMatchReward, (int,int)> primaryIndexSelector;

        public EntityMPvpGradeOneMatchRewardTable(EntityMPvpGradeOneMatchReward[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.PvpGradeOneMatchRewardId,element.PvpRewardId);
        }
        
    }
}
