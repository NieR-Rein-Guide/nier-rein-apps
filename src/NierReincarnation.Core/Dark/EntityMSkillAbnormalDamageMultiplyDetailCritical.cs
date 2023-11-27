using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalDamageMultiplyDetailCritical))]
public class EntityMSkillAbnormalDamageMultiplyDetailCritical
{
    [Key(0)]
    public int DamageMultiplyAbnormalDetailId { get; set; }

    [Key(1)]
    public bool IsCritical { get; set; }

    [Key(2)]
    public int DamageMultiplyCoefficientValuePermil { get; set; }
}
