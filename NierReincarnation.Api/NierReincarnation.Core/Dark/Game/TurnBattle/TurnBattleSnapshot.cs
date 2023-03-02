using System.Collections.Generic;
using MessagePack;

namespace NierReincarnation.Core.Dark.Game.TurnBattle
{
    [MessagePackObject]
    public class TurnBattleSnapshot
    {
        [Key(0)] // RVA: 0x1DEBF5C Offset: 0x1DEBF5C VA: 0x1DEBF5C
        public int TurnBattleSnapshotVersion { get; set; }
        [Key(1)] // RVA: 0x1DEBF70 Offset: 0x1DEBF70 VA: 0x1DEBF70
        public TurnBattleBattleSnapshot BattleSnapshot { get; set; }
        [Key(2)] // RVA: 0x1DEBF84 Offset: 0x1DEBF84 VA: 0x1DEBF84
        public List<TurnBattleActorSnapshot> ActorSnapshots { get; set; } = new List<TurnBattleActorSnapshot>();
        [Key(3)] // RVA: 0x1DEBF98 Offset: 0x1DEBF98 VA: 0x1DEBF98
        public List<TurnBattleSkillSnapshot> SkillSnapshots { get; set; } = new List<TurnBattleSkillSnapshot>();
        [Key(4)] // RVA: 0x1DEBFAC Offset: 0x1DEBFAC VA: 0x1DEBFAC
        public List<TurnBattleSkillBehaviourSnapshot> SkillBehaviourSnapshots { get; set; } = new List<TurnBattleSkillBehaviourSnapshot>();
    }
}
