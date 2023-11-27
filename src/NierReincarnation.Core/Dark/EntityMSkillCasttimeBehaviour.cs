using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillCasttimeBehaviour))]
public class EntityMSkillCasttimeBehaviour
{
    [Key(0)]
    public int SkillCasttimeBehaviourId { get; set; }

    [Key(1)]
    public SkillCasttimeBehaviourType SkillCasttimeBehaviourType { get; set; }

    [Key(2)]
    public int SkillCasttimeBehaviourActionId { get; set; }
}
