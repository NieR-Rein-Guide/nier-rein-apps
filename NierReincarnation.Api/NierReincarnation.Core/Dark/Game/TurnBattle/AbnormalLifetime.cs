using System.Collections.Generic;
using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Game.TurnBattle
{
    [MessagePackObject]
    public class AbnormalLifetime
    {
        [Key(0)] // RVA: 0x1DEBFC0 Offset: 0x1DEBFC0 VA: 0x1DEBFC0
        public AbnormalHash AbnormalHash { get; set; }
        [Key(1)] // RVA: 0x1DEBFD4 Offset: 0x1DEBFD4 VA: 0x1DEBFD4
        public List<AbnormalLifetimeMethodType> AbnormalLifetimeMethodTypes { get; set; }
        [Key(2)] // RVA: 0x1DEBFE8 Offset: 0x1DEBFE8 VA: 0x1DEBFE8
        public List<int> CurrentLifetimes { get; set; }
        [Key(3)] // RVA: 0x1DEBFFC Offset: 0x1DEBFFC VA: 0x1DEBFFC
        public List<int> MaxLifetimes { get; set; }
        [Key(4)] // RVA: 0x1DEC010 Offset: 0x1DEC010 VA: 0x1DEC010
        public AbnormalLifetimeBehaviourConditionType AbnormalLifetimeBehaviourConditionType { get; set; }
        [Key(5)] // RVA: 0x1DEC024 Offset: 0x1DEC024 VA: 0x1DEC024
        public int AttachedOrder { get; set; }
    }
}
