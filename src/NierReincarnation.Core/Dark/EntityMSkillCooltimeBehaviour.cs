using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillCooltimeBehaviour))]
public class EntityMSkillCooltimeBehaviour
{
    [Key(0)]
    public int SkillCooltimeBehaviourId { get; set; }

    [Key(1)]
    public SkillCooltimeBehaviourType SkillCooltimeBehaviourType { get; set; }

    [Key(2)]
    public int SkillCooltimeBehaviourActionId { get; set; }
}
