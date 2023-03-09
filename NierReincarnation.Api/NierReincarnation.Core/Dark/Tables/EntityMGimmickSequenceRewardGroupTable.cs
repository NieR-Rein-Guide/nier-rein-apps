using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMGimmickSequenceRewardGroupTable : TableBase<EntityMGimmickSequenceRewardGroup>
    {
        private readonly Func<EntityMGimmickSequenceRewardGroup, (int,int)> primaryIndexSelector;

        public EntityMGimmickSequenceRewardGroupTable(EntityMGimmickSequenceRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.GimmickSequenceRewardGroupId,element.GroupIndex);
        }
        
    }
}
