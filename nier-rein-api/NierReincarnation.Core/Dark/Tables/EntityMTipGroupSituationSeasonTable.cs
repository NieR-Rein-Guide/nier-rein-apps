using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMTipGroupSituationSeasonTable : TableBase<EntityMTipGroupSituationSeason>
    {
        private readonly Func<EntityMTipGroupSituationSeason, (int,int,int)> primaryIndexSelector;

        public EntityMTipGroupSituationSeasonTable(EntityMTipGroupSituationSeason[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.TipSituationType,element.TipSituationSeasonId,element.TipGroupId);
        }
        
    }
}
