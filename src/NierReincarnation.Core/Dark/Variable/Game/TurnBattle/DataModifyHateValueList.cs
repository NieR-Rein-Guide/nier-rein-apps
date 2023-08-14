using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataModifyHateValueList
{
    [Key(0)]
    public List<DataModifyHateValue> List { get; set; } = new List<DataModifyHateValue>();
}
