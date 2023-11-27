using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActivationConditionGroup))]
public class EntityMSkillBehaviourActivationConditionGroup
{
    [Key(0)]
    public int SkillBehaviourActivationConditionGroupId { get; set; }

    [Key(1)]
    public int ConditionCheckOrder { get; set; }

    [Key(2)]
    public SkillBehaviourActivationConditionType SkillBehaviourActivationConditionType { get; set; }

    [Key(3)]
    public int SkillBehaviourActivationConditionId { get; set; }
}
