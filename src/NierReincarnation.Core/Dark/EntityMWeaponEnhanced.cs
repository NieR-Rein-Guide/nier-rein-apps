using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMWeaponEnhanced))]
public class EntityMWeaponEnhanced
{
    [Key(0)]
    public int WeaponEnhancedId { get; set; }

    [Key(1)]
    public int WeaponId { get; set; }

    [Key(2)]
    public int Level { get; set; }

    [Key(3)]
    public int LimitBreakCount { get; set; }
}
