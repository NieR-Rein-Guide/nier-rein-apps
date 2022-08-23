using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_evolution_group")]
    public class EntityMWeaponEvolutionGroup
    {
        [Key(0)] // RVA: 0x1DE6C00 Offset: 0x1DE6C00 VA: 0x1DE6C00
        public int WeaponEvolutionGroupId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DE6C68 Offset: 0x1DE6C68 VA: 0x1DE6C68
        public int EvolutionOrder { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DE6CA8 Offset: 0x1DE6CA8 VA: 0x1DE6CA8
        public int WeaponId { get; set; } // 0x18
	}
}
