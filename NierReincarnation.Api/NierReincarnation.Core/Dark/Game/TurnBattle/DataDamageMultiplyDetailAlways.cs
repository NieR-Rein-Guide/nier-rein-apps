using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyDetailAlways
{
    [Key(0)] // RVA: 0x1DEC17C Offset: 0x1DEC17C VA: 0x1DEC17C
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }
    [Key(1)] // RVA: 0x1DEC190 Offset: 0x1DEC190 VA: 0x1DEC190
    public int CoefficientValuePermil { get; set; }
}
