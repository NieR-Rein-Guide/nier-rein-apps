using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCageOrnamentTable : TableBase<EntityMCageOrnament>
    {
        private readonly Func<EntityMCageOrnament, int> primaryIndexSelector;

        public EntityMCageOrnamentTable(EntityMCageOrnament[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CageOrnamentId;
        }
        
        public EntityMCageOrnament FindByCageOrnamentId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

	
        public bool TryFindByCageOrnamentId(int key, out EntityMCageOrnament result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

	
        public RangeView<EntityMCageOrnament> FindRangeByCageOrnamentId(int min, int max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<int>.Default, min, max, ascendant); }

    }
}
