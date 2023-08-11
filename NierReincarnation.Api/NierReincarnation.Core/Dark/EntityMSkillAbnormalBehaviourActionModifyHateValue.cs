using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_abnormal_behaviour_action_modify_hate_value")]
public class EntityMSkillAbnormalBehaviourActionModifyHateValue
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public HateValueCalculationType HateValueCalculationType { get; set; }

    [Key(2)]
    public int ModifyValue { get; set; }
}
