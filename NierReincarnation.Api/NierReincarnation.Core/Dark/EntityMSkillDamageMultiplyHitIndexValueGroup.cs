using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_damage_multiply_hit_index_value_group")]
public class EntityMSkillDamageMultiplyHitIndexValueGroup
{
    [Key(0)]
    public int SkillDamageMultiplyHitIndexValueGroupId { get; set; }

    [Key(1)]
    public int SkillDamageMultiplyHitIndexValueGroupIndex { get; set; }

    [Key(2)]
    public int TotalHitCountConditionLower { get; set; }

    [Key(3)]
    public int TotalHitCountConditionUpper { get; set; }

    [Key(4)]
    public int HitIndex { get; set; }

    [Key(5)]
    public int DamageMultiplyCoefficientValuePermil { get; set; }
}
