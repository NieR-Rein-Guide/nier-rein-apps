using System;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPowerCalculationConstantValueTable : TableBase<EntityMPowerCalculationConstantValue> // TypeDefIndex: 12083
    {
        // Fields
        private readonly Func<EntityMPowerCalculationConstantValue, PowerCalculationConstantValueType> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C54220 Offset: 0x2C54220 VA: 0x2C54220
        public EntityMPowerCalculationConstantValueTable(EntityMPowerCalculationConstantValue[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = value => value.PowerCalculationConstantValueType;
        }
    }
}
