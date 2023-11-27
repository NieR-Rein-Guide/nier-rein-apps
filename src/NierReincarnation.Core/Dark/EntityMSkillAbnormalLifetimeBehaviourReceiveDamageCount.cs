using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalLifetimeBehaviourReceiveDamageCount))]
public class EntityMSkillAbnormalLifetimeBehaviourReceiveDamageCount
{
    [Key(0)]
    public int SkillAbnormalLifetimeBehaviourId { get; set; }

    [Key(1)]
    public int ReceiveDamageCount { get; set; }
}
