using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyDetailBuffAttached
{
    [Key(0)] // RVA: 0x1E75CB0 Offset: 0x1E75CB0 VA: 0x1E75CB0
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }

    [Key(1)] // RVA: 0x1E75CC4 Offset: 0x1E75CC4 VA: 0x1E75CC4
    public DamageMultiplyBuffAttachedConditionTargetType ConditionTargetType { get; set; }

    [Key(2)] // RVA: 0x1E75CD8 Offset: 0x1E75CD8 VA: 0x1E75CD8
    public DamageMultiplyBuffAttachedTargetBuffType TargetBuffType { get; set; }

    [Key(3)] // RVA: 0x1E75CEC Offset: 0x1E75CEC VA: 0x1E75CEC
    public DamageMultiplyBuffAttachedTargetStatusKindType TargetStatusKindType { get; set; }

    [Key(4)] // RVA: 0x1E75D00 Offset: 0x1E75D00 VA: 0x1E75D00
    public int DamageMultiplyCoefficientValuePermil { get; set; }
}
