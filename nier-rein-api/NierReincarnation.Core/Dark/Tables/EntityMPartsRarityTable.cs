using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPartsRarityTable : TableBase<EntityMPartsRarity>
    {
        private readonly Func<EntityMPartsRarity, int> primaryIndexSelector;

        public EntityMPartsRarityTable(EntityMPartsRarity[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.RarityType;
        }
        
        public EntityMPartsRarity FindByRarityType(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
