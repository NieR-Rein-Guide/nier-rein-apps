using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_special_act_active_skill_condition_attribute")]
    public class EntityMCostumeSpecialActActiveSkillConditionAttribute
    {
        [Key(0)]
        public int CostumeSpecialActActiveSkillConditionId { get; set; } // 0x10

        [Key(1)]
        public int CostumeSpecialActActiveSkillConditionAttributeType { get; set; } // 0x14
    }
}
