using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_weapon")]
    public class EntityMBattleNpcWeapon
    {
        [Key(0)] // RVA: 0x1DD8F4C Offset: 0x1DD8F4C VA: 0x1DD8F4C
        public long BattleNpcId { get; set; }
        [Key(1)] // RVA: 0x1DD8F8C Offset: 0x1DD8F8C VA: 0x1DD8F8C
        public string BattleNpcWeaponUuid { get; set; }
        [Key(2)] // RVA: 0x1DD8FCC Offset: 0x1DD8FCC VA: 0x1DD8FCC
        public int WeaponId { get; set; }
        [Key(3)] // RVA: 0x1DD8FE0 Offset: 0x1DD8FE0 VA: 0x1DD8FE0
        public int Level { get; set; }
        [Key(4)] // RVA: 0x1DD8FF4 Offset: 0x1DD8FF4 VA: 0x1DD8FF4
        public int Exp { get; set; }
        [Key(5)] // RVA: 0x1DD9008 Offset: 0x1DD9008 VA: 0x1DD9008
        public int LimitBreakCount { get; set; }
        [Key(6)] // RVA: 0x1DD901C Offset: 0x1DD901C VA: 0x1DD901C
        public bool IsProtected { get; set; }
        [Key(7)] // RVA: 0x1DD9030 Offset: 0x1DD9030 VA: 0x1DD9030
        public long AcquisitionDatetime { get; set; }
	}
}
