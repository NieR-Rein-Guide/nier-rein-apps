using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_damage_multiply_detail_critical")]
public class EntityMSkillDamageMultiplyDetailCritical
{
    [Key(0)]
    public int SkillDamageMultiplyDetailId { get; set; }

    [Key(1)]
    public bool IsCritical { get; set; }

    [Key(2)]
    public int DamageMultiplyCoefficientValuePermil { get; set; }
}
