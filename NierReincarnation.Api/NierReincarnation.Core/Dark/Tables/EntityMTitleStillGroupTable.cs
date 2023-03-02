using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMTitleStillGroupTable : TableBase<EntityMTitleStillGroup>
    {
        private readonly Func<EntityMTitleStillGroup, int> primaryIndexSelector;

        public EntityMTitleStillGroupTable(EntityMTitleStillGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.TitleStillGroupId;
        }
        
    }
}
