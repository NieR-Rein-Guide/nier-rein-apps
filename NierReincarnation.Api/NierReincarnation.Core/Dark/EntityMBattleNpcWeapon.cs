using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_weapon")]
    public class EntityMBattleNpcWeapon
    {
        [Key(0)] // RVA: 0x1DD8F4C Offset: 0x1DD8F4C VA: 0x1DD8F4C
        public long BattleNpcId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DD8F8C Offset: 0x1DD8F8C VA: 0x1DD8F8C
        public string BattleNpcWeaponUuid { get; set; } // 0x18

        [Key(2)] // RVA: 0x1DD8FCC Offset: 0x1DD8FCC VA: 0x1DD8FCC
        public int WeaponId { get; set; } // 0x20

        [Key(3)] // RVA: 0x1DD8FE0 Offset: 0x1DD8FE0 VA: 0x1DD8FE0
        public int Level { get; set; } // 0x24

        [Key(4)] // RVA: 0x1DD8FF4 Offset: 0x1DD8FF4 VA: 0x1DD8FF4
        public int Exp { get; set; } // 0x28

        [Key(5)] // RVA: 0x1DD9008 Offset: 0x1DD9008 VA: 0x1DD9008
        public int LimitBreakCount { get; set; } // 0x2C

        [Key(6)] // RVA: 0x1DD901C Offset: 0x1DD901C VA: 0x1DD901C
        public bool IsProtected { get; set; } // 0x30

        [Key(7)] // RVA: 0x1DD9030 Offset: 0x1DD9030 VA: 0x1DD9030
        public long AcquisitionDatetime { get; set; } // 0x38
    }
}
