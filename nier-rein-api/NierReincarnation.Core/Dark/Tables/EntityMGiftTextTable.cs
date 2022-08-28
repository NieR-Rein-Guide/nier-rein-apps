using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMGiftTextTable : TableBase<EntityMGiftText>
    {
        private readonly Func<EntityMGiftText, (int,int)> primaryIndexSelector;

        public EntityMGiftTextTable(EntityMGiftText[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.GiftTextId,element.LanguageType);
        }
        
        public EntityMGiftText FindByGiftTextIdAndLanguageType(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}
