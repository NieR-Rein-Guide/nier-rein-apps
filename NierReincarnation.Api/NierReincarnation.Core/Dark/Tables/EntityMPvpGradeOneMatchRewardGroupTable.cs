using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPvpGradeOneMatchRewardGroupTable : TableBase<EntityMPvpGradeOneMatchRewardGroup>
    {
        private readonly Func<EntityMPvpGradeOneMatchRewardGroup, (int,int)> primaryIndexSelector;

        public EntityMPvpGradeOneMatchRewardGroupTable(EntityMPvpGradeOneMatchRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.PvpGradeOneMatchRewardGroupId,element.PvpGradeOneMatchRewardId);
        }
        
    }
}
