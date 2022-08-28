using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeDisplayCoordinateAdjustmentTable : TableBase<EntityMCostumeDisplayCoordinateAdjustment>
    {
        private readonly Func<EntityMCostumeDisplayCoordinateAdjustment, (int,int)> primaryIndexSelector;

        public EntityMCostumeDisplayCoordinateAdjustmentTable(EntityMCostumeDisplayCoordinateAdjustment[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeId,element.DisplayCoordinateAdjustmentFunctionType);
        }
        
        public EntityMCostumeDisplayCoordinateAdjustment FindByCostumeIdAndDisplayCoordinateAdjustmentFunctionType(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}
