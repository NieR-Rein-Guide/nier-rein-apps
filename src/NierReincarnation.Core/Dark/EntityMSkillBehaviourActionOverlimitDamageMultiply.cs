using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionOverlimitDamageMultiply))]
public class EntityMSkillBehaviourActionOverlimitDamageMultiply
{
    public int SkillBehaviourActionId { get; set; }

    public DamageMultiplyDetailType DamageMultiplyDetailType { get; set; }

    public int SkillDamageMultiplyDetailId { get; set; }

    public DamageMultiplyTargetType DamageMultiplyTargetType { get; set; }
}
