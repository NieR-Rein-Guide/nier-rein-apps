using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyDetailCritical
{
    [Key(0)] // RVA: 0x1DEC1A4 Offset: 0x1DEC1A4 VA: 0x1DEC1A4
    public bool IsCriticalCondition { get; set; }

    [Key(1)] // RVA: 0x1DEC1B8 Offset: 0x1DEC1B8 VA: 0x1DEC1B8
    public int CoefficientValuePermil { get; set; }

    [Key(2)] // RVA: 0x1DEC1CC Offset: 0x1DEC1CC VA: 0x1DEC1CC
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }
}
