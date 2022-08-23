using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_skill_group")]
    public class EntityMWeaponSkillGroup
    {
        [Key(0)] // RVA: 0x1DE7078 Offset: 0x1DE7078 VA: 0x1DE7078
        public int WeaponSkillGroupId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DE70B8 Offset: 0x1DE70B8 VA: 0x1DE70B8
        public int SlotNumber { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DE70F8 Offset: 0x1DE70F8 VA: 0x1DE70F8
        public int SkillId { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DE710C Offset: 0x1DE710C VA: 0x1DE710C
        public int WeaponSkillEnhancementMaterialId { get; set; } // 0x1C
	}
}
