using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle
{
    [MessagePackObject]
    public class BuffResistanceValue
    {
        [Key(0)] // RVA: 0x1DEB7FC Offset: 0x1DEB7FC VA: 0x1DEB7FC
        public BuffResistanceType BuffType { get; set; }
        [Key(1)] // RVA: 0x1DEB810 Offset: 0x1DEB810 VA: 0x1DEB810
        public BuffResistanceStatusKindType StatusKindType { get; set; }
        [Key(2)] // RVA: 0x1DEB824 Offset: 0x1DEB824 VA: 0x1DEB824
        public int BlockProbabilityPermil { get; set; }
	}
}
