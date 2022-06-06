using System.Collections.Generic;
using MessagePack;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle
{
    // TODO: Deserialization problems? Necessary to resolve?
    [MessagePackObject]
    public class OverrideHitEffectValues
    {
        [Key(0)] // RVA: 0x1DEB900 Offset: 0x1DEB900 VA: 0x1DEB900
        public List<OverrideHitEffectValue> List { get; set; } = new List<OverrideHitEffectValue>();
    }
}
