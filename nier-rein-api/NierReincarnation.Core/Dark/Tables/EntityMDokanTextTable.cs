using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMDokanTextTable : TableBase<EntityMDokanText>
    {
        private readonly Func<EntityMDokanText, (int,int)> primaryIndexSelector;

        public EntityMDokanTextTable(EntityMDokanText[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.DokanTextId,element.LanguageType);
        }
        
        public EntityMDokanText FindByDokanTextIdAndLanguageType(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}
