using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_ability_status")]
    public class EntityMAbilityStatus
    {
        [Key(0)] // RVA: 0x1DD6638 Offset: 0x1DD6638 VA: 0x1DD6638
        public int AbilityStatusId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DD6678 Offset: 0x1DD6678 VA: 0x1DD6678
        public int Agility { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DD668C Offset: 0x1DD668C VA: 0x1DD668C
        public int Attack { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DD66A0 Offset: 0x1DD66A0 VA: 0x1DD66A0
        public int CriticalAttackRatioPermil { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1DD66B4 Offset: 0x1DD66B4 VA: 0x1DD66B4
        public int CriticalRatioPermil { get; set; } // 0x20

        [Key(5)] // RVA: 0x1DD66C8 Offset: 0x1DD66C8 VA: 0x1DD66C8
        public int EvasionRatioPermil { get; set; } // 0x24

        [Key(6)] // RVA: 0x1DD66DC Offset: 0x1DD66DC VA: 0x1DD66DC
        public int Hp { get; set; } // 0x28

        [Key(7)] // RVA: 0x1DD66F0 Offset: 0x1DD66F0 VA: 0x1DD66F0
        public int Vitality { get; set; } // 0x2C
    }
}
