using System.Collections.Generic;
using MessagePack;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle
{
    [MessagePackObject]
    public class BuffResistanceValues
    {
        [Key(0)] // RVA: 0x1DEB7E8 Offset: 0x1DEB7E8 VA: 0x1DEB7E8
        public List<BuffResistanceValue> List { get; set; } = new List<BuffResistanceValue>();
    }
}
