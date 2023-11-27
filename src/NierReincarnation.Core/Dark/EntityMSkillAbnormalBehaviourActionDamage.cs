using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalBehaviourActionDamage))]
public class EntityMSkillAbnormalBehaviourActionDamage
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public AbnormalBehaviourDamageType AbnormalBehaviourDamageType { get; set; }

    [Key(2)]
    public int Power { get; set; }
}
