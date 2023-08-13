using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPowerCalculationConstantValueTable : TableBase<EntityMPowerCalculationConstantValue>
{
    private readonly Func<EntityMPowerCalculationConstantValue, PowerCalculationConstantValueType> primaryIndexSelector;

    public EntityMPowerCalculationConstantValueTable(EntityMPowerCalculationConstantValue[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.PowerCalculationConstantValueType;
    }
}
