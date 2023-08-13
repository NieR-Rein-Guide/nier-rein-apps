using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_abnormal_behaviour_action_abnormal_resistance")]
public class EntityMSkillAbnormalBehaviourActionAbnormalResistance
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public AbnormalResistancePolarityType AbnormalResistancePolarityType { get; set; }

    [Key(2)]
    public int AbnormalResistanceSkillAbnormalTypeId { get; set; }

    [Key(3)]
    public int BlockProbabilityPermil { get; set; }
}
