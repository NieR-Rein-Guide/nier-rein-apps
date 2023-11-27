using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_damage_multiply_detail_specified_costume_type")]
public class EntityMSkillDamageMultiplyDetailSpecifiedCostumeType
{
    public int SkillDamageMultiplyDetailId { get; set; }

    public DamageMultiplySpecifiedCostumeConditionTargetType SpecifiedCostumeConditionTargetType { get; set; }

    public int TargetSpecifiedCostumeGroupId { get; set; }

    public int DamageMultiplyCoefficientValuePermil { get; set; }
}
