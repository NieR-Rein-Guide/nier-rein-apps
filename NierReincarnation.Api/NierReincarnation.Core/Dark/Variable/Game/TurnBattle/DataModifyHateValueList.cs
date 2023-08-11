using System.Collections.Generic;
using MessagePack;
using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataModifyHateValueList
{
    [Key(0)] // RVA: 0x1DEB89C Offset: 0x1DEB89C VA: 0x1DEB89C
    public List<DataModifyHateValue> List { get; set; } = new List<DataModifyHateValue>();
}
