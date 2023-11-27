using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMWeaponAwakenEffectGroup))]
public class EntityMWeaponAwakenEffectGroup
{
    [Key(0)]
    public int WeaponAwakenEffectGroupId { get; set; }

    [Key(1)]
    public int WeaponAwakenEffectType { get; set; }

    [Key(2)]
    public int WeaponAwakenEffectId { get; set; }
}
