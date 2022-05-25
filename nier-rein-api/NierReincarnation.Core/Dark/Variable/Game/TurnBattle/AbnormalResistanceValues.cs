using System.Collections.Generic;
using MessagePack;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle
{
    [MessagePackObject]
    public class AbnormalResistanceValues
    {
        [Key(0)] // RVA: 0x1DEB688 Offset: 0x1DEB688 VA: 0x1DEB688
        public List<AbnormalResistanceValue> List { get; set; } = new List<AbnormalResistanceValue>();
    }
}
