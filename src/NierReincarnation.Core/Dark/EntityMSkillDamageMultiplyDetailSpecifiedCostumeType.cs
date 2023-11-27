using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillDamageMultiplyDetailSpecifiedCostumeType))]
public class EntityMSkillDamageMultiplyDetailSpecifiedCostumeType
{
    public int SkillDamageMultiplyDetailId { get; set; }

    public DamageMultiplySpecifiedCostumeConditionTargetType SpecifiedCostumeConditionTargetType { get; set; }

    public int TargetSpecifiedCostumeGroupId { get; set; }

    public int DamageMultiplyCoefficientValuePermil { get; set; }
}
