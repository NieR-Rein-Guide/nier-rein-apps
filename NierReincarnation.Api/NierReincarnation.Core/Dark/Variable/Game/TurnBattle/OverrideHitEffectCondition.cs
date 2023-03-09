using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle
{
    [MessagePackObject]
    public class OverrideHitEffectCondition
    {
        [Key(0)]
        public object Unk1 { get; set; }
        [Key(1)] // RVA: 0x1DEB9B4 Offset: 0x1DEB9B4 VA: 0x1DEB9B4
        public OverrideHitEffectConditionType? ConditionType { get; set; }
        [Key(2)] // RVA: 0x1DEB9C8 Offset: 0x1DEB9C8 VA: 0x1DEB9C8
        public int ConditionIndex { get; set; }
        [Key(3)] // RVA: 0x1DEB9DC Offset: 0x1DEB9DC VA: 0x1DEB9DC
        public int ConditionValue { get; set; }
    }
}
