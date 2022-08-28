using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMHelpTable : TableBase<EntityMHelp>
    {
        private readonly Func<EntityMHelp, int> primaryIndexSelector;
        private readonly Func<EntityMHelp, int> secondaryIndexSelector;

        public EntityMHelpTable(EntityMHelp[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.HelpType;
            secondaryIndexSelector = element => element.HelpPageGroupId;
        }
        
        public bool TryFindByHelpType(int key, out EntityMHelp result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
