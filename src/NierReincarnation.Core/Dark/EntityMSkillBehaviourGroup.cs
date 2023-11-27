using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourGroup))]
public class EntityMSkillBehaviourGroup
{
    [Key(0)]
    public int SkillBehaviourGroupId { get; set; }

    [Key(1)]
    public int SkillBehaviourId { get; set; }

    [Key(2)]
    public int SkillBehaviourIndex { get; set; }

    [Key(3)]
    public int TargetSelectorIndex { get; set; }

    [Key(4)]
    public int SkillHitStartIndex { get; set; }

    [Key(5)]
    public int SkillHitEndIndex { get; set; }
}
