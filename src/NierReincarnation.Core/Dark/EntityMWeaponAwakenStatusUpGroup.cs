using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMWeaponAwakenStatusUpGroup))]
public class EntityMWeaponAwakenStatusUpGroup
{
    [Key(0)]
    public int WeaponAwakenStatusUpGroupId { get; set; }

    [Key(1)]
    public StatusKindType StatusKindType { get; set; }

    [Key(2)]
    public StatusCalculationType StatusCalculationType { get; set; }

    [Key(3)]
    public int EffectValue { get; set; }
}
