using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalDamageMultiplyDetailAbnormal))]
public class EntityMSkillAbnormalDamageMultiplyDetailAbnormal
{
    [Key(0)]
    public int DamageMultiplyAbnormalDetailId { get; set; }

    [Key(1)]
    public int SkillDamageMultiplyAbnormalAttachedValueGroupId { get; set; }
}
