using System.Collections.Generic;
using MessagePack;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class AttributeDamageCorrectionValues
{
    [Key(0)] // RVA: 0x1DEB784 Offset: 0x1DEB784 VA: 0x1DEB784
    public List<AttributeDamageCorrectionValue> List { get; set; } = new List<AttributeDamageCorrectionValue>();
}
