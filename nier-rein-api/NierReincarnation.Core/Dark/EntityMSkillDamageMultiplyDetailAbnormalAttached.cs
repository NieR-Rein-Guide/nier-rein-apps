using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_damage_multiply_detail_abnormal_attached")]
    public class EntityMSkillDamageMultiplyDetailAbnormalAttached
    {
        [Key(0)]
        public int SkillDamageMultiplyDetailId { get; set; } // 0x10
        [Key(1)]
        public int SkillDamageMultiplyAbnormalAttachedValueGroupId { get; set; } // 0x14
    }
}