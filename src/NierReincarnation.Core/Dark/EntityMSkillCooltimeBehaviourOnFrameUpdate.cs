using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillCooltimeBehaviourOnFrameUpdate))]
public class EntityMSkillCooltimeBehaviourOnFrameUpdate
{
    [Key(0)]
    public int SkillCooltimeBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillCooltimeAdvanceValuePerFrame { get; set; }
}
