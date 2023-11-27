using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillCasttimeBehaviourActionOnSkillDamageCondition))]
public class EntityMSkillCasttimeBehaviourActionOnSkillDamageCondition
{
    [Key(0)]
    public int SkillCasttimeBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillCasttimeUpdateValue { get; set; }

    [Key(2)]
    public SkillCasttimeAdvanceType SkillCasttimeAdvanceType { get; set; }

    [Key(3)]
    public int DamageCompareType { get; set; }

    [Key(4)]
    public int DamageConditionValue { get; set; }
}
