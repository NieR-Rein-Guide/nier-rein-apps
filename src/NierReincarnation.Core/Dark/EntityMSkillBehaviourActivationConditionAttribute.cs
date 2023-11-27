using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActivationConditionAttribute))]
public class EntityMSkillBehaviourActivationConditionAttribute
{
    [Key(0)]
    public int SkillBehaviourActivationConditionId { get; set; }

    [Key(1)]
    public int SkillBehaviourActivationConditionAttributeType { get; set; }
}
