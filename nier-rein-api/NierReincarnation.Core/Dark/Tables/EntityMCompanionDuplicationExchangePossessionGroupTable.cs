using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCompanionDuplicationExchangePossessionGroupTable : TableBase<EntityMCompanionDuplicationExchangePossessionGroup>
    {
        private readonly Func<EntityMCompanionDuplicationExchangePossessionGroup, (int, PossessionType)> primaryIndexSelector;

        public EntityMCompanionDuplicationExchangePossessionGroupTable(EntityMCompanionDuplicationExchangePossessionGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CompanionId,element.PossessionType);
        }
        
    }
}
