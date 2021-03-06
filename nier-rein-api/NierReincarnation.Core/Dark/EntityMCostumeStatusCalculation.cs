using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_status_calculation")]
    public class EntityMCostumeStatusCalculation
    {
        [Key(0)] // RVA: 0x1DDCC3C Offset: 0x1DDCC3C VA: 0x1DDCC3C
        public int CostumeStatusCalculationId { get; set; }
        [Key(1)] // RVA: 0x1DDCC7C Offset: 0x1DDCC7C VA: 0x1DDCC7C
        public int HpNumericalFunctionId { get; set; }
        [Key(2)] // RVA: 0x1DDCC90 Offset: 0x1DDCC90 VA: 0x1DDCC90
        public int AttackNumericalFunctionId { get; set; }
        [Key(3)] // RVA: 0x1DDCCA4 Offset: 0x1DDCCA4 VA: 0x1DDCCA4
        public int VitalityNumericalFunctionId { get; set; }
        [Key(4)] // RVA: 0x1DDCCB8 Offset: 0x1DDCCB8 VA: 0x1DDCCB8
        public int AgilityNumericalFunctionId { get; set; } // 0x20
        [Key(5)] // RVA: 0x1DDCCCC Offset: 0x1DDCCCC VA: 0x1DDCCCC
        public int CriticalRatioPermilNumericalFunctionId { get; set; }
        [Key(6)] // RVA: 0x1DDCCE0 Offset: 0x1DDCCE0 VA: 0x1DDCCE0
        public int CriticalAttackRatioPermilNumericalFunctionId { get; set; }
        [Key(7)] // RVA: 0x1DDCCF4 Offset: 0x1DDCCF4 VA: 0x1DDCCF4
        public int EvasionRatioPermilNumericalFunctionId { get; set; }
	}
}
