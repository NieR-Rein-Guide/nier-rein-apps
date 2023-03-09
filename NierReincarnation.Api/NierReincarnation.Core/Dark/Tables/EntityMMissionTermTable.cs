using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMMissionTermTable : TableBase<EntityMMissionTerm>
    {
        private readonly Func<EntityMMissionTerm, int> primaryIndexSelector;

        public EntityMMissionTermTable(EntityMMissionTerm[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.MissionTermId;
        }
        
        public EntityMMissionTerm FindByMissionTermId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
