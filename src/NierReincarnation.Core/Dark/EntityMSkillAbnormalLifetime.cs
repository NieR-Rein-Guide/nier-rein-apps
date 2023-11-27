using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalLifetime))]
public class EntityMSkillAbnormalLifetime
{
    [Key(0)]
    public int SkillAbnormalLifetimeId { get; set; }

    [Key(1)]
    public int SkillAbnormalLifetimeBehaviourGroupId { get; set; }

    [Key(2)]
    public AbnormalLifetimeBehaviourConditionType AbnormalLifetimeBehaviourConditionType { get; set; }
}
