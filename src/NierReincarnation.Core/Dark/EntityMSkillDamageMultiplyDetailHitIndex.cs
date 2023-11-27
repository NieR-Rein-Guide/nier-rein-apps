using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillDamageMultiplyDetailHitIndex))]
public class EntityMSkillDamageMultiplyDetailHitIndex
{
    [Key(0)]
    public int SkillDamageMultiplyDetailId { get; set; }

    [Key(1)]
    public int SkillDamageMultiplyHitIndexValueGroupId { get; set; }
}
