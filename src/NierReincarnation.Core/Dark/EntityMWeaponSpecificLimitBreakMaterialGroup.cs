using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMWeaponSpecificLimitBreakMaterialGroup))]
public class EntityMWeaponSpecificLimitBreakMaterialGroup
{
    [Key(0)]
    public int WeaponSpecificLimitBreakMaterialGroupId { get; set; }

    [Key(1)]
    public int LimitBreakCountLowerLimit { get; set; }

    [Key(2)]
    public int MaterialId { get; set; }

    [Key(3)]
    public int Count { get; set; }

    [Key(4)]
    public int SortOrder { get; set; }
}
