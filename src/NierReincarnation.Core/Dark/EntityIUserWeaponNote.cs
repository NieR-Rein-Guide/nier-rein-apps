using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserWeaponNote))]
public class EntityIUserWeaponNote
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int WeaponId { get; set; }

    [Key(2)]
    public int MaxLevel { get; set; }

    [Key(3)]
    public int MaxLimitBreakCount { get; set; }

    [Key(4)]
    public long FirstAcquisitionDatetime { get; set; }

    [Key(5)]
    public long LatestVersion { get; set; }
}
