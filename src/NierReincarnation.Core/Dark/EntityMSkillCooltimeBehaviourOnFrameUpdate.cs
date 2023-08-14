using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_cooltime_behaviour_on_frame_update")]
public class EntityMSkillCooltimeBehaviourOnFrameUpdate
{
    [Key(0)]
    public int SkillCooltimeBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillCooltimeAdvanceValuePerFrame { get; set; }
}
