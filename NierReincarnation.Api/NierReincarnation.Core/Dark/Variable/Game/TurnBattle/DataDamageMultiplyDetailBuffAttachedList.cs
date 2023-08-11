using System.Collections.Generic;
using MessagePack;
using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyDetailBuffAttachedList
{
    [Key(0)] // RVA: 0x1E75344 Offset: 0x1E75344 VA: 0x1E75344
    public List<DataDamageMultiplyDetailBuffAttached> List { get; set; } = new List<DataDamageMultiplyDetailBuffAttached>();
}
