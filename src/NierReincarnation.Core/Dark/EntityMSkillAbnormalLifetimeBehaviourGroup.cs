using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalLifetimeBehaviourGroup))]
public class EntityMSkillAbnormalLifetimeBehaviourGroup
{
    [Key(0)]
    public int SkillAbnormalLifetimeBehaviourGroupId { get; set; }

    [Key(1)]
    public int AbnormalLifetimeBehaviourIndex { get; set; }

    [Key(2)]
    public AbnormalLifetimeMethodType AbnormalLifetimeMethodType { get; set; }

    [Key(3)]
    public int SkillAbnormalLifetimeBehaviourId { get; set; }
}
