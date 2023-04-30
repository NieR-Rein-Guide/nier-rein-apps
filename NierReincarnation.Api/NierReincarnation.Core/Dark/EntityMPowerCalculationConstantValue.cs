using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_power_calculation_constant_value")]
    public class EntityMPowerCalculationConstantValue
    {
        [Key(0)] // RVA: 0x1DE0D5C Offset: 0x1DE0D5C VA: 0x1DE0D5C
        public PowerCalculationConstantValueType PowerCalculationConstantValueType { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DE0D9C Offset: 0x1DE0D9C VA: 0x1DE0D9C
        public int ConstantValue { get; set; } // 0x14
    }
}
