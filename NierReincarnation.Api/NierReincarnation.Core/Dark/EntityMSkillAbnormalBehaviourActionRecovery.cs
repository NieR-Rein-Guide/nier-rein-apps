using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_abnormal_behaviour_action_recovery")]
public class EntityMSkillAbnormalBehaviourActionRecovery
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public AbnormalBehaviourRecoveryType AbnormalBehaviourRecoveryType { get; set; }

    [Key(2)]
    public int Value { get; set; }

    [Key(3)]
    public int Upper { get; set; }
}
