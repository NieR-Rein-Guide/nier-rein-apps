using System.Collections.Generic;
using MessagePack;
using NierReincarnation.Core.Dark.Game.TurnBattle;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle
{
    [MessagePackObject]
    public class DataDamageMultiplyAbnormalAttachedList
    {
        [Key(0)] // RVA: 0x1DEB838 Offset: 0x1DEB838 VA: 0x1DEB838
        public List<DataDamageMultiplyAbnormalAttachedValue> List { get; set; } = new List<DataDamageMultiplyAbnormalAttachedValue>();
    }
}
