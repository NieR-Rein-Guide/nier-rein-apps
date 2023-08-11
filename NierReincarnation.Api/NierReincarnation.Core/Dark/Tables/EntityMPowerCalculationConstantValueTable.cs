using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPowerCalculationConstantValueTable : TableBase<EntityMPowerCalculationConstantValue>
{
    private readonly Func<EntityMPowerCalculationConstantValue, PowerCalculationConstantValueType> primaryIndexSelector;

    public EntityMPowerCalculationConstantValueTable(EntityMPowerCalculationConstantValue[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.PowerCalculationConstantValueType;
    }
}
