using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_companion_status_calculation")]
    public class EntityMCompanionStatusCalculation
    {
        [Key(0)] // RVA: 0x1DDB8E8 Offset: 0x1DDB8E8 VA: 0x1DDB8E8
        public int CompanionStatusCalculationId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DDB928 Offset: 0x1DDB928 VA: 0x1DDB928
        public int AttackNumericalFunctionId { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DDB93C Offset: 0x1DDB93C VA: 0x1DDB93C
        public int HpNumericalFunctionId { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DDB950 Offset: 0x1DDB950 VA: 0x1DDB950
        public int VitalityNumericalFunctionId { get; set; } // 0x1C
	}
}
