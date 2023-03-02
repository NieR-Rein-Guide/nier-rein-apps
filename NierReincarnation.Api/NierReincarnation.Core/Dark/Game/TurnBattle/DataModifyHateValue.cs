using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Game.TurnBattle
{
    [MessagePackObject]
    public class DataModifyHateValue
    {
        [Key(0)] // RVA: 0x1DEC2A8 Offset: 0x1DEC2A8 VA: 0x1DEC2A8
        public HateValueCalculationType CalculationType { get; set; }
        [Key(1)] // RVA: 0x1DEC2BC Offset: 0x1DEC2BC VA: 0x1DEC2BC
        public int ModifyValue { get; set; }
    }
}
