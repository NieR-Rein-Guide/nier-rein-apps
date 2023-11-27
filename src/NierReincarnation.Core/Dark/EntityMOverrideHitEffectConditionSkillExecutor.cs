using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMOverrideHitEffectConditionSkillExecutor))]
public class EntityMOverrideHitEffectConditionSkillExecutor
{
    [Key(0)]
    public int OverrideHitEffectConditionId { get; set; }

    [Key(1)]
    public int SkillOwnerCategoryType { get; set; }
}
