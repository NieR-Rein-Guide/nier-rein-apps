using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalDamageMultiplyDetailBuffAttached))]
public class EntityMSkillAbnormalDamageMultiplyDetailBuffAttached
{
    [Key(0)]
    public int DamageMultiplyAbnormalDetailId { get; set; }

    [Key(1)]
    public int BuffAttachedTargetType { get; set; }

    [Key(2)]
    public int TargetBuffType { get; set; }

    [Key(3)]
    public int TargetStatusKindType { get; set; }

    [Key(4)]
    public int DamageMultiplyCoefficientValuePermil { get; set; }
}
