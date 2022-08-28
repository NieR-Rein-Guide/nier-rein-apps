using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCollectionBonusEffectTable : TableBase<EntityMCollectionBonusEffect>
    {
        private readonly Func<EntityMCollectionBonusEffect, (int,int)> primaryIndexSelector;

        public EntityMCollectionBonusEffectTable(EntityMCollectionBonusEffect[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CollectionBonusEffectId,element.CollectionBonusEffectType);
        }
        
        public EntityMCollectionBonusEffect FindByCollectionBonusEffectIdAndCollectionBonusEffectType(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

	
        public RangeView<EntityMCollectionBonusEffect> FindRangeByCollectionBonusEffectIdAndCollectionBonusEffectType(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, min, max, ascendant); }

    }
}
