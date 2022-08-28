using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_damage_multiply_detail_hit_index")]
    public class EntityMSkillAbnormalDamageMultiplyDetailHitIndex
    {
        [Key(0)]
        public int DamageMultiplyAbnormalDetailId { get; set; } // 0x10
        [Key(1)]
        public int SkillDamageMultiplyHitIndexValueGroupId { get; set; } // 0x14
    }
}