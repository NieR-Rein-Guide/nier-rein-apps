using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_weapon_skill_group")]
public class EntityMWeaponSkillGroup
{
    [Key(0)]
    public int WeaponSkillGroupId { get; set; }

    [Key(1)]
    public int SlotNumber { get; set; }

    [Key(2)]
    public int SkillId { get; set; }

    [Key(3)]
    public int WeaponSkillEnhancementMaterialId { get; set; }
}
