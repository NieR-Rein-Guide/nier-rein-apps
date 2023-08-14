using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyHitIndexList
{
    [Key(0)]
    public List<DataDamageMultiplyHitIndexValue> List { get; set; } = new List<DataDamageMultiplyHitIndexValue>();
}
