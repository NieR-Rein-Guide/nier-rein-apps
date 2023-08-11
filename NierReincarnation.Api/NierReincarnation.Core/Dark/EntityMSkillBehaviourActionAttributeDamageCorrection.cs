using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_behaviour_action_attribute_damage_correction")]
public class EntityMSkillBehaviourActionAttributeDamageCorrection
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int AttributeType { get; set; }

    [Key(2)]
    public CorrectionTargetDamageType CorrectionTargetDamageType { get; set; }

    [Key(3)]
    public int CorrectionValuePermil { get; set; }

    [Key(4)]
    public DamageCorrectionOverlapType DamageCorrectionOverlapType { get; set; }

    [Key(5)]
    public bool IsExcepting { get; set; }
}
