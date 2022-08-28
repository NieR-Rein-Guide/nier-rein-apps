using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMUserLevelTable : TableBase<EntityMUserLevel>
    {
        private readonly Func<EntityMUserLevel, int> primaryIndexSelector;

        public EntityMUserLevelTable(EntityMUserLevel[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserLevel;
        }
        
        public EntityMUserLevel FindByUserLevel(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
