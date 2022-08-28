using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCompleteMissionGroupTable : TableBase<EntityMCompleteMissionGroup>
    {
        private readonly Func<EntityMCompleteMissionGroup, (int,int,int)> primaryIndexSelector;

        public EntityMCompleteMissionGroupTable(EntityMCompleteMissionGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.MissionId,element.PossessionType,element.PossessionId);
        }
        
    }
}
