using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalLifetimeBehaviourTurnCount))]
public class EntityMSkillAbnormalLifetimeBehaviourTurnCount
{
    [Key(0)]
    public int SkillAbnormalLifetimeBehaviourId { get; set; }

    [Key(1)]
    public int TurnCount { get; set; }
}
