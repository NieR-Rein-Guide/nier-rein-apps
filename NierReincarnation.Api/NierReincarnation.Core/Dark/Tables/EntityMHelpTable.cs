using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMHelpTable : TableBase<EntityMHelp>
    {
        private readonly Func<EntityMHelp, HelpType> primaryIndexSelector;
        private readonly Func<EntityMHelp, int> secondaryIndexSelector;

        public EntityMHelpTable(EntityMHelp[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.HelpType;
            secondaryIndexSelector = element => element.HelpPageGroupId;
        }

        public bool TryFindByHelpType(HelpType key, out EntityMHelp result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<HelpType>.Default, key, out result);
    }
}
