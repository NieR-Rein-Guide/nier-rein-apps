using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCompleteMissionGroupTable : TableBase<EntityMCompleteMissionGroup>
    {
        private readonly Func<EntityMCompleteMissionGroup, (int, PossessionType, int)> primaryIndexSelector;

        public EntityMCompleteMissionGroupTable(EntityMCompleteMissionGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.MissionId,element.PossessionType,element.PossessionId);
        }
        
    }
}
