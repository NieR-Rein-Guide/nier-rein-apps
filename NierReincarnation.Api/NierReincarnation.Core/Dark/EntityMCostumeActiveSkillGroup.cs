using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_active_skill_group")]
    public class EntityMCostumeActiveSkillGroup
    {
        [Key(0)] // RVA: 0x1DDC164 Offset: 0x1DDC164 VA: 0x1DDC164
        public int CostumeActiveSkillGroupId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DDC1A4 Offset: 0x1DDC1A4 VA: 0x1DDC1A4
        public int CostumeLimitBreakCountLowerLimit { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DDC1E4 Offset: 0x1DDC1E4 VA: 0x1DDC1E4
        public int CostumeActiveSkillId { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DDC1F8 Offset: 0x1DDC1F8 VA: 0x1DDC1F8
        public int CostumeActiveSkillEnhancementMaterialId { get; set; } // 0x1C
	}
}
