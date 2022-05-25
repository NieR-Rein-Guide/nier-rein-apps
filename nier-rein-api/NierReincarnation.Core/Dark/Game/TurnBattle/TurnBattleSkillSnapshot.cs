using System.Collections.Generic;
using MessagePack;

namespace NierReincarnation.Core.Dark.Game.TurnBattle
{
    [MessagePackObject]
    public class TurnBattleSkillSnapshot
    {
        [Key(0)] // RVA: 0x1DEBEE4 Offset: 0x1DEBEE4 VA: 0x1DEBEE4
        public ProgressDataKey ProgressDataKey { get; set; }
        [Key(1)] // RVA: 0x1DEBEF8 Offset: 0x1DEBEF8 VA: 0x1DEBEF8
        public SkillHash SkillHash { get; set; }
        [Key(2)] // RVA: 0x1DEBF0C Offset: 0x1DEBF0C VA: 0x1DEBF0C
        public int DynamicCurrentCoolTime { get; set; }
        [Key(3)] // RVA: 0x1DEBF20 Offset: 0x1DEBF20 VA: 0x1DEBF20
        public int DynamicMaxCoolTime { get; set; }
        [Key(4)] // RVA: 0x1DEBF34 Offset: 0x1DEBF34 VA: 0x1DEBF34
        public int UsedCount { get; set; }
        [Key(5)] // RVA: 0x1DEBF48 Offset: 0x1DEBF48 VA: 0x1DEBF48
        public List<int> CoolTimeModifyValueList { get; set; } = new List<int>();
    }
}
