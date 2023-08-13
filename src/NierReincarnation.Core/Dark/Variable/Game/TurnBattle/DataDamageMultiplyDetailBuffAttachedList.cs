using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyDetailBuffAttachedList
{
    [Key(0)]
    public List<DataDamageMultiplyDetailBuffAttached> List { get; set; } = new List<DataDamageMultiplyDetailBuffAttached>();
}
