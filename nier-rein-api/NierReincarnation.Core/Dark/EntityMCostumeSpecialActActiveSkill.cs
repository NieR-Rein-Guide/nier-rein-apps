using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_special_act_active_skill")]
    public class EntityMCostumeSpecialActActiveSkill
    {
        [Key(0)]
        public int CostumeId { get; set; } // 0x10
        [Key(1)]
        public int SkillActIndex { get; set; } // 0x14
    }
}