using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMNumericalFunctionTable : TableBase<EntityMNumericalFunction> // TypeDefIndex: 12031
    {
        // Fields
        private readonly Func<EntityMNumericalFunction, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C5080C Offset: 0x2C5080C VA: 0x2C5080C
        public EntityMNumericalFunctionTable(EntityMNumericalFunction[] sortedData):base(sortedData)
        {
            primaryIndexSelector = function => function.NumericalFunctionId;
        }

        // RVA: 0x2C5090C Offset: 0x2C5090C VA: 0x2C5090C
        public EntityMNumericalFunction FindByNumericalFunctionId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}
