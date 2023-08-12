using MessagePack;
using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyCriticalList
{
    [Key(0)] // RVA: 0x1DEB860 Offset: 0x1DEB860 VA: 0x1DEB860
    public List<DataDamageMultiplyDetailCritical> List { get; set; } = new List<DataDamageMultiplyDetailCritical>();
}
