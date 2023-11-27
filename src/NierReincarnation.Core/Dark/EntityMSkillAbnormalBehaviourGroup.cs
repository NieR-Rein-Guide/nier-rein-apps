using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalBehaviourGroup))]
public class EntityMSkillAbnormalBehaviourGroup
{
    [Key(0)]
    public int SkillAbnormalBehaviourGroupId { get; set; }

    [Key(1)]
    public int AbnormalBehaviourIndex { get; set; }

    [Key(2)]
    public int SkillAbnormalBehaviourId { get; set; }
}
