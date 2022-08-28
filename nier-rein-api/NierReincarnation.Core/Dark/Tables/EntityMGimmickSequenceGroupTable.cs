using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMGimmickSequenceGroupTable : TableBase<EntityMGimmickSequenceGroup>
    {
        private readonly Func<EntityMGimmickSequenceGroup, (int,int)> primaryIndexSelector;

        public EntityMGimmickSequenceGroupTable(EntityMGimmickSequenceGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.GimmickSequenceGroupId,element.GroupIndex);
        }
        
    }
}
