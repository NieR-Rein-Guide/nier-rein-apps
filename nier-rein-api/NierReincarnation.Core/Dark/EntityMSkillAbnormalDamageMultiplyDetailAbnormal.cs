using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_damage_multiply_detail_abnormal")]
    public class EntityMSkillAbnormalDamageMultiplyDetailAbnormal
    {
        [Key(0)]
        public int DamageMultiplyAbnormalDetailId { get; set; } // 0x10
        [Key(1)]
        public int SkillDamageMultiplyAbnormalAttachedValueGroupId { get; set; } // 0x14
    }
}