using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlways))]
public class EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlways
{
    [Key(0)]
    public int DamageMultiplyAbnormalDetailId { get; set; }

    [Key(1)]
    public int DamageMultiplyCoefficientValuePermil { get; set; }
}
