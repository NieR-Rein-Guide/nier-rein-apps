using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyCriticalList
{
    [Key(0)]
    public List<DataDamageMultiplyDetailCritical> List { get; set; } = new List<DataDamageMultiplyDetailCritical>();
}
