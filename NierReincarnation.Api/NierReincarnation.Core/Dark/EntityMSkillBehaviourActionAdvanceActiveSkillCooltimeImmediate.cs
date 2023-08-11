using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_behaviour_action_advance_active_skill_cooltime_immediate")]
public class EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediate
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public SkillCooltimeAdvanceType SkillCooltimeAdvanceType { get; set; }

    [Key(2)]
    public ActiveSkillType ActiveSkillType { get; set; }

    [Key(3)]
    public int AdvanceValue { get; set; }
}
