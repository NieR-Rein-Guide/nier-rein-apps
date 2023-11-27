using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionDamageMultiply))]
public class EntityMSkillBehaviourActionDamageMultiply
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public DamageMultiplyDetailType DamageMultiplyDetailType { get; set; }

    [Key(2)]
    public int SkillDamageMultiplyDetailId { get; set; }

    [Key(3)]
    public DamageMultiplyTargetType DamageMultiplyTargetType { get; set; }
}
