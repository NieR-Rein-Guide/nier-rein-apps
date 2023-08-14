using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_power_calculation_constant_value")]
public class EntityMPowerCalculationConstantValue
{
    [Key(0)]
    public PowerCalculationConstantValueType PowerCalculationConstantValueType { get; set; }

    [Key(1)]
    public int ConstantValue { get; set; }
}
