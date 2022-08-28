using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMTipGroupSituationTable : TableBase<EntityMTipGroupSituation>
    {
        private readonly Func<EntityMTipGroupSituation, (int,int)> primaryIndexSelector;

        public EntityMTipGroupSituationTable(EntityMTipGroupSituation[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.TipSituationType,element.TipGroupId);
        }
        
    }
}
