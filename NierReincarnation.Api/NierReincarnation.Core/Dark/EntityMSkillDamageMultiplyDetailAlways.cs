using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_damage_multiply_detail_always")]
    public class EntityMSkillDamageMultiplyDetailAlways
    {
        [Key(0)]
        public int SkillDamageMultiplyDetailId { get; set; } // 0x10

        [Key(1)]
        public int DamageMultiplyCoefficientValuePermil { get; set; } // 0x14
    }
}
