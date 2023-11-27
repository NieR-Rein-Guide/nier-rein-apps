using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillCooltimeBehaviourGroup))]
public class EntityMSkillCooltimeBehaviourGroup
{
    [Key(0)]
    public int SkillCooltimeBehaviourGroupId { get; set; }

    [Key(1)]
    public int SkillCooltimeBehaviourId { get; set; }
}
