using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_weapon_ability_group")]
public class EntityMWeaponAbilityGroup
{
    [Key(0)] // RVA: 0x1DE68A4 Offset: 0x1DE68A4 VA: 0x1DE68A4
    public int WeaponAbilityGroupId { get; set; }

    [Key(1)] // RVA: 0x1DE68E4 Offset: 0x1DE68E4 VA: 0x1DE68E4
    public int SlotNumber { get; set; }

    [Key(2)] // RVA: 0x1DE6924 Offset: 0x1DE6924 VA: 0x1DE6924
    public int AbilityId { get; set; }

    [Key(3)] // RVA: 0x1DE6938 Offset: 0x1DE6938 VA: 0x1DE6938
    public int WeaponAbilityEnhancementMaterialId { get; set; }
}
