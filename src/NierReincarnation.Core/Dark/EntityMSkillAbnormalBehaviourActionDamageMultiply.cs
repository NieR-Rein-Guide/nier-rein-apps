using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalBehaviourActionDamageMultiply))]
public class EntityMSkillAbnormalBehaviourActionDamageMultiply
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public DamageMultiplyDetailType DamageMultiplyDetailType { get; set; }

    [Key(2)]
    public DamageMultiplyTargetType DamageMultiplyTargetType { get; set; }

    [Key(3)]
    public int DamageMultiplyAbnormalDetailId { get; set; }
}
