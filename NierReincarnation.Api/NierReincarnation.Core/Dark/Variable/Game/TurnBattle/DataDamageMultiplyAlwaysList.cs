using MessagePack;
using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyAlwaysList
{
    [Key(0)] // RVA: 0x1DEB84C Offset: 0x1DEB84C VA: 0x1DEB84C
    public List<DataDamageMultiplyDetailAlways> List { get; set; } = new List<DataDamageMultiplyDetailAlways>();
}
