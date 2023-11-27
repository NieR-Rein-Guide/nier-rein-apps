using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionAttackVitality))]
public class EntityMSkillBehaviourActionAttackVitality
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillPower { get; set; }

    [Key(2)]
    public int AttackWeight { get; set; }

    [Key(3)]
    public int VitalityWeight { get; set; }
}
