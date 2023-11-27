using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillDamageMultiplyDetailAbnormalAttached))]
public class EntityMSkillDamageMultiplyDetailAbnormalAttached
{
    [Key(0)]
    public int SkillDamageMultiplyDetailId { get; set; }

    [Key(1)]
    public int SkillDamageMultiplyAbnormalAttachedValueGroupId { get; set; }
}
