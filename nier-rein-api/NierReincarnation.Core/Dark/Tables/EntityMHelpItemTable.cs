using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMHelpItemTable : TableBase<EntityMHelpItem>
    {
        private readonly Func<EntityMHelpItem, int> primaryIndexSelector;
        private readonly Func<EntityMHelpItem, int> secondaryIndexSelector;

        public EntityMHelpItemTable(EntityMHelpItem[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.HelpItemId;
            secondaryIndexSelector = element => element.HelpCategoryId;
        }
        
        public EntityMHelpItem FindByHelpItemId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

	
        public RangeView<EntityMHelpItem> FindByHelpCategoryId(int key) { return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key); }

    }
}
