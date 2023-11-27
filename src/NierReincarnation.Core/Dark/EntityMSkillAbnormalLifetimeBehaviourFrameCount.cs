using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalLifetimeBehaviourFrameCount))]
public class EntityMSkillAbnormalLifetimeBehaviourFrameCount
{
    [Key(0)]
    public int SkillAbnormalLifetimeBehaviourId { get; set; }

    [Key(1)]
    public int FrameCount { get; set; }
}
