using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMImportantItemTable : TableBase<EntityMImportantItem> // TypeDefIndex: 13928
    {
        // Fields
        private readonly Func<EntityMImportantItem, int> primaryIndexSelector; // 0x18

        private readonly Func<EntityMImportantItem, int> secondaryIndexSelector; // 0x28

        // Methods

        // RVA: 0x33D5D04 Offset: 0x33D5D04 VA: 0x33D5D04
        public EntityMImportantItemTable(EntityMImportantItem[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = item => item.ImportantItemId;
        }

        // RVA: 0x33D5EBC Offset: 0x33D5EBC VA: 0x33D5EBC
        public EntityMImportantItem FindByImportantItemId(int key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

        // RVA: 0x33D5F50 Offset: 0x33D5F50 VA: 0x33D5F50
        public bool TryFindByImportantItemId(int key, out EntityMImportantItem result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

        // RVA: 0x33D5FF8 Offset: 0x33D5FF8 VA: 0x33D5FF8
        public RangeView<EntityMImportantItem> FindByImportantItemType(int key)
        { return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key); }
    }
}
