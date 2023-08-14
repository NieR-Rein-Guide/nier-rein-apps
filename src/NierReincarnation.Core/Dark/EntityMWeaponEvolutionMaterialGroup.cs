using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_weapon_evolution_material_group")]
public class EntityMWeaponEvolutionMaterialGroup
{
    [Key(0)]
    public int WeaponEvolutionMaterialGroupId { get; set; }

    [Key(1)]
    public int MaterialId { get; set; }

    [Key(2)]
    public int Count { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }
}
