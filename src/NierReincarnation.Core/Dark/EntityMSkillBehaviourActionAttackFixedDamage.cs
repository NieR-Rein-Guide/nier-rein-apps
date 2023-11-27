using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionAttackFixedDamage))]
public class EntityMSkillBehaviourActionAttackFixedDamage
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int DamageValue { get; set; }

    [Key(2)]
    public bool ForceDamage { get; set; }
}
