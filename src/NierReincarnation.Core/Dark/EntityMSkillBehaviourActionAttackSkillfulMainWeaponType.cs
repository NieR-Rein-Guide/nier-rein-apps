using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionAttackSkillfulMainWeaponType))]
public class EntityMSkillBehaviourActionAttackSkillfulMainWeaponType
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillPower { get; set; }

    [Key(2)]
    public int MagnificationRate { get; set; }
}
