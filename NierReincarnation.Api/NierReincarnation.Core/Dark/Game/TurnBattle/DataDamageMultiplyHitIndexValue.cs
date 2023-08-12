using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyHitIndexValue
{
    [Key(0)] // RVA: 0x1DEC244 Offset: 0x1DEC244 VA: 0x1DEC244
    public int TotalHitCountConditionLower { get; set; }

    [Key(1)] // RVA: 0x1DEC258 Offset: 0x1DEC258 VA: 0x1DEC258
    public int TotalHitCountConditionUpper { get; set; }

    [Key(2)] // RVA: 0x1DEC26C Offset: 0x1DEC26C VA: 0x1DEC26C
    public int HitIndex { get; set; }

    [Key(3)] // RVA: 0x1DEC280 Offset: 0x1DEC280 VA: 0x1DEC280
    public int CoefficientValuePermil { get; set; }

    [Key(4)] // RVA: 0x1DEC294 Offset: 0x1DEC294 VA: 0x1DEC294
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }
}
