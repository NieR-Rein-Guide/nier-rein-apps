using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_casttime_behaviour_action_on_frame_update")]
public class EntityMSkillCasttimeBehaviourActionOnFrameUpdate
{
    [Key(0)]
    public int SkillCasttimeBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillCasttimeAdvanceValuePerFrame { get; set; }
}
