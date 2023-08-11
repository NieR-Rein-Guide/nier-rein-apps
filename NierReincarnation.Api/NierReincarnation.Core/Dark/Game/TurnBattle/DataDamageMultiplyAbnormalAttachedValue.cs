using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyAbnormalAttachedValue
{
    [Key(0)] // RVA: 0x1DEC118 Offset: 0x1DEC118 VA: 0x1DEC118
    public DamageMultiplyAbnormalAttachedPolarityConditionType PolarityConditionType { get; set; }
    [Key(1)] // RVA: 0x1DEC12C Offset: 0x1DEC12C VA: 0x1DEC12C
    public int AbnormalTypeIdCondition { get; set; }
    [Key(2)] // RVA: 0x1DEC140 Offset: 0x1DEC140 VA: 0x1DEC140
    public DamageMultiplyAbnormalAttachedTargetType ReferenceActorType { get; set; }
    [Key(3)] // RVA: 0x1DEC154 Offset: 0x1DEC154 VA: 0x1DEC154
    public int CoefficientValuePermil { get; set; }
    [Key(4)] // RVA: 0x1DEC168 Offset: 0x1DEC168 VA: 0x1DEC168
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }
	}
