using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeDisplayCoordinateAdjustmentTable : TableBase<EntityMCostumeDisplayCoordinateAdjustment>
    {
        private readonly Func<EntityMCostumeDisplayCoordinateAdjustment, (int, DisplayCoordinateAdjustmentFunctionType)> primaryIndexSelector;

        public EntityMCostumeDisplayCoordinateAdjustmentTable(EntityMCostumeDisplayCoordinateAdjustment[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeId, element.DisplayCoordinateAdjustmentFunctionType);
        }

        public EntityMCostumeDisplayCoordinateAdjustment FindByCostumeIdAndDisplayCoordinateAdjustmentFunctionType(ValueTuple<int, DisplayCoordinateAdjustmentFunctionType> key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<(int, DisplayCoordinateAdjustmentFunctionType)>.Default, key);
    }
}
