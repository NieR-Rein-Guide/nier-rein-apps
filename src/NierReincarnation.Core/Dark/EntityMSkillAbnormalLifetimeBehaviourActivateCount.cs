using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalLifetimeBehaviourActivateCount))]
public class EntityMSkillAbnormalLifetimeBehaviourActivateCount
{
    [Key(0)]
    public int SkillAbnormalLifetimeBehaviourId { get; set; }

    [Key(1)]
    public int ActivateCount { get; set; }

    [Key(2)]
    public int AbnormalBehaviourIndex { get; set; }
}
