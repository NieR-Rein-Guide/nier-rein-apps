using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCatalogWeapon))]
public class EntityMCatalogWeapon
{
    [Key(0)]
    public int WeaponId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int CatalogTermId { get; set; }
}
