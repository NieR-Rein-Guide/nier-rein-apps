using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPortalCageAccessPointFunctionGroupTable : TableBase<EntityMPortalCageAccessPointFunctionGroup>
    {
        private readonly Func<EntityMPortalCageAccessPointFunctionGroup, (int,int)> primaryIndexSelector;

        public EntityMPortalCageAccessPointFunctionGroupTable(EntityMPortalCageAccessPointFunctionGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.AccessPointFunctionGroupId,element.AccessPointFunctionIndex);
        }
        
        public EntityMPortalCageAccessPointFunctionGroup FindByAccessPointFunctionGroupIdAndAccessPointFunctionIndex(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

	
        public RangeView<EntityMPortalCageAccessPointFunctionGroup> FindRangeByAccessPointFunctionGroupIdAndAccessPointFunctionIndex(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, min, max, ascendant); }

    }
}
