using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMMissionTable : TableBase<EntityMMission>
    {
        private readonly Func<EntityMMission, int> primaryIndexSelector;

        public EntityMMissionTable(EntityMMission[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.MissionId;
        }
        
        public EntityMMission FindByMissionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
