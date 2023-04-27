using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMMissionPassTable : TableBase<EntityMMissionPass>
    {
        private readonly Func<EntityMMissionPass, int> primaryIndexSelector;

        public EntityMMissionPassTable(EntityMMissionPass[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.MissionPassId;
        }

        public EntityMMissionPass FindByMissionPassId(int key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }
    }
}
