using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyAlwaysList
{
    [Key(0)]
    public List<DataDamageMultiplyDetailAlways> List { get; set; } = new List<DataDamageMultiplyDetailAlways>();
}
