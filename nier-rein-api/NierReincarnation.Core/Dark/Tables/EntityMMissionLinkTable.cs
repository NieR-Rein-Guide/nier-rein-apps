using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMMissionLinkTable : TableBase<EntityMMissionLink>
    {
        private readonly Func<EntityMMissionLink, int> primaryIndexSelector;

        public EntityMMissionLinkTable(EntityMMissionLink[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.MissionLinkId;
        }
        
        public EntityMMissionLink FindByMissionLinkId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
