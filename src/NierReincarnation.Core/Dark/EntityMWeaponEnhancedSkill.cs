using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMWeaponEnhancedSkill))]
public class EntityMWeaponEnhancedSkill
{
    [Key(0)]
    public int WeaponEnhancedId { get; set; }

    [Key(1)]
    public int SkillId { get; set; }

    [Key(2)]
    public int Level { get; set; }
}
