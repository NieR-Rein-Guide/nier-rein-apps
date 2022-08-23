using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_base_status")]
    public class EntityMWeaponBaseStatus
    {
        [Key(0)] // RVA: 0x1DE694C Offset: 0x1DE694C VA: 0x1DE694C
        public int WeaponBaseStatusId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DE698C Offset: 0x1DE698C VA: 0x1DE698C
        public int Hp { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DE69A0 Offset: 0x1DE69A0 VA: 0x1DE69A0
        public int Attack { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DE69B4 Offset: 0x1DE69B4 VA: 0x1DE69B4
        public int Vitality { get; set; } // 0x1C
	}
}
