using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalDamageMultiplyDetailHitIndex))]
public class EntityMSkillAbnormalDamageMultiplyDetailHitIndex
{
    [Key(0)]
    public int DamageMultiplyAbnormalDetailId { get; set; }

    [Key(1)]
    public int SkillDamageMultiplyHitIndexValueGroupId { get; set; }
}
