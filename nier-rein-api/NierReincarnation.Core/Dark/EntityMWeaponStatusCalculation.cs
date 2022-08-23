using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_status_calculation")]
    public class EntityMWeaponStatusCalculation
    {
        [Key(0)] // RVA: 0x1DE734C Offset: 0x1DE734C VA: 0x1DE734C
        public int WeaponStatusCalculationId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DE738C Offset: 0x1DE738C VA: 0x1DE738C
        public int HpNumericalFunctionId { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DE73A0 Offset: 0x1DE73A0 VA: 0x1DE73A0
        public int AttackNumericalFunctionId { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DE73B4 Offset: 0x1DE73B4 VA: 0x1DE73B4
        public int VitalityNumericalFunctionId { get; set; } // 0x1C
	}
}
