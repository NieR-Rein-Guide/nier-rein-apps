using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_weapon_evolution_group")]
public class EntityMWeaponEvolutionGroup
{
    [Key(0)]
    public int WeaponEvolutionGroupId { get; set; }

    [Key(1)]
    public int EvolutionOrder { get; set; }

    [Key(2)]
    public int WeaponId { get; set; }
}
