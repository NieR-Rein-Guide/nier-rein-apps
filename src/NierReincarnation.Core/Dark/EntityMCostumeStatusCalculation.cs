using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_status_calculation")]
public class EntityMCostumeStatusCalculation
{
    [Key(0)]
    public int CostumeStatusCalculationId { get; set; }

    [Key(1)]
    public int HpNumericalFunctionId { get; set; }

    [Key(2)]
    public int AttackNumericalFunctionId { get; set; }

    [Key(3)]
    public int VitalityNumericalFunctionId { get; set; }

    [Key(4)]
    public int AgilityNumericalFunctionId { get; set; }

    [Key(5)]
    public int CriticalRatioPermilNumericalFunctionId { get; set; }

    [Key(6)]
    public int CriticalAttackRatioPermilNumericalFunctionId { get; set; }

    [Key(7)]
    public int EvasionRatioPermilNumericalFunctionId { get; set; }
}
