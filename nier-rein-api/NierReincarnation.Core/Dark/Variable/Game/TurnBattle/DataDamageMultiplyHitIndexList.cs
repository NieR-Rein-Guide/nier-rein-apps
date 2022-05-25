using System.Collections.Generic;
using MessagePack;
using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle
{
    [MessagePackObject]
    public class DataDamageMultiplyHitIndexList
    {
        [Key(0)] // RVA: 0x1DEB874 Offset: 0x1DEB874 VA: 0x1DEB874
        public List<DataDamageMultiplyHitIndexValue> List { get; set; } = new List<DataDamageMultiplyHitIndexValue>();
    }
}
