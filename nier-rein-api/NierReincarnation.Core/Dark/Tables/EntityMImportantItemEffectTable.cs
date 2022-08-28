using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMImportantItemEffectTable : TableBase<EntityMImportantItemEffect>
    {
        private readonly Func<EntityMImportantItemEffect, int> primaryIndexSelector;

        public EntityMImportantItemEffectTable(EntityMImportantItemEffect[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ImportantItemEffectId;
        }
        
        public EntityMImportantItemEffect FindByImportantItemEffectId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
