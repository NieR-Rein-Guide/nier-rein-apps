using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillCasttimeBehaviourActionOnFrameUpdate))]
public class EntityMSkillCasttimeBehaviourActionOnFrameUpdate
{
    [Key(0)]
    public int SkillCasttimeBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillCasttimeAdvanceValuePerFrame { get; set; }
}
