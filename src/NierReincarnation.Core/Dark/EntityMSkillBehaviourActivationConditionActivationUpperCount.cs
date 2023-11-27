using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActivationConditionActivationUpperCount))]
public class EntityMSkillBehaviourActivationConditionActivationUpperCount
{
    [Key(0)]
    public int SkillBehaviourActivationConditionId { get; set; }

    [Key(1)]
    public int ActivationUpperCount { get; set; }
}
