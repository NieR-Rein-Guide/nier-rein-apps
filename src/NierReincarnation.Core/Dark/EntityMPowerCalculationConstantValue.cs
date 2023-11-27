using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPowerCalculationConstantValue))]
public class EntityMPowerCalculationConstantValue
{
    [Key(0)]
    public PowerCalculationConstantValueType PowerCalculationConstantValueType { get; set; }

    [Key(1)]
    public int ConstantValue { get; set; }
}
