using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_behaviour_activation_method")]
public class EntityMSkillBehaviourActivationMethod
{
    [Key(0)]
    public int SkillBehaviourActivationMethodId { get; set; }

    [Key(1)]
    public ActivationMethodType ActivationMethodType { get; set; }

    [Key(2)]
    public int SkillBehaviourActivationConditionGroupId { get; set; }
}
