namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class OverrideHitEffectValue
{
    [Key(0)]
    public int OverrideEffectId { get; set; }

    [Key(1)]
    public int OverrideSeId { get; set; }

    [Key(2)]
    public int Priority { get; set; }

    [Key(3)]
    public bool DisablePlayHitVoice { get; set; }

    [Key(4)]
    public bool PlayOnMiss { get; set; }

    [Key(5)]
    public bool ForceRotateOnHit { get; set; }

    [Key(6)]
    public List<OverrideHitEffectCondition> Conditions { get; set; } = new List<OverrideHitEffectCondition>();

    [Key(7)]
    public ConditionOperationType ConditionOperationType { get; set; }
}
