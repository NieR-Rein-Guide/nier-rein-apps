using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionAttackMainWeaponAttribute))]
public class EntityMSkillBehaviourActionAttackMainWeaponAttribute
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillPower { get; set; }

    [Key(2)]
    public AttributeType AttributeType { get; set; }

    [Key(3)]
    public int MagnificationRate { get; set; }
}
