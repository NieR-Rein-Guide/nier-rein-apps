using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyAbnormalAttachedList
{
    [Key(0)]
    public List<DataDamageMultiplyAbnormalAttachedValue> List { get; set; } = new List<DataDamageMultiplyAbnormalAttachedValue>();
}
