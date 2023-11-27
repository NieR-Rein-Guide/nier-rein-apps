using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActivationConditionInSkillFlow))]
public class EntityMSkillBehaviourActivationConditionInSkillFlow
{
    [Key(0)]
    public int SkillBehaviourActivationConditionId { get; set; }

    [Key(1)]
    public int RunningSkillBehaviourType { get; set; }
}
