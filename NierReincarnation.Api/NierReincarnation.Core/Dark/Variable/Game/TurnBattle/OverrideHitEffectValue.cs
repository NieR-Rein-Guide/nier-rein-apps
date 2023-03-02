using System.Collections.Generic;
using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle
{
    [MessagePackObject]
    public class OverrideHitEffectValue
    {
        [Key(0)] // RVA: 0x1DEB914 Offset: 0x1DEB914 VA: 0x1DEB914
        public int OverrideEffectId { get; set; }
        [Key(1)] // RVA: 0x1DEB928 Offset: 0x1DEB928 VA: 0x1DEB928
        public int OverrideSeId { get; set; }
        [Key(2)] // RVA: 0x1DEB93C Offset: 0x1DEB93C VA: 0x1DEB93C
        public int Priority { get; set; }
        [Key(3)] // RVA: 0x1DEB950 Offset: 0x1DEB950 VA: 0x1DEB950
        public bool DisablePlayHitVoice { get; set; }
        [Key(4)] // RVA: 0x1DEB964 Offset: 0x1DEB964 VA: 0x1DEB964
        public bool PlayOnMiss { get; set; }
        [Key(5)] // RVA: 0x1DEB978 Offset: 0x1DEB978 VA: 0x1DEB978
        public bool ForceRotateOnHit { get; set; }
        [Key(6)] // RVA: 0x1DEB98C Offset: 0x1DEB98C VA: 0x1DEB98C
        public List<OverrideHitEffectCondition> Conditions { get; set; } = new List<OverrideHitEffectCondition>();
        [Key(7)] // RVA: 0x1DEB9A0 Offset: 0x1DEB9A0 VA: 0x1DEB9A0
        public ConditionOperationType ConditionOperationType { get; set; }
    }
}
