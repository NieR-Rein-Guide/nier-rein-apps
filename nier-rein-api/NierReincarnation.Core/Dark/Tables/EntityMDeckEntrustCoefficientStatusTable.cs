using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMDeckEntrustCoefficientStatusTable : TableBase<EntityMDeckEntrustCoefficientStatus>
    {
        private readonly Func<EntityMDeckEntrustCoefficientStatus, (int,int)> primaryIndexSelector;

        public EntityMDeckEntrustCoefficientStatusTable(EntityMDeckEntrustCoefficientStatus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EntrustDeckStatusType,element.DeckStatusType);
        }
        
    }
}
