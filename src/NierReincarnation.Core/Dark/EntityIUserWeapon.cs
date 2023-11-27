using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserWeapon))]
public class EntityIUserWeapon
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserWeaponUuid { get; set; }

    [Key(2)]
    public int WeaponId { get; set; }

    [Key(3)]
    public int Level { get; set; }

    [Key(4)]
    public int Exp { get; set; }

    [Key(5)]
    public int LimitBreakCount { get; set; }

    [Key(6)]
    public bool IsProtected { get; set; }

    [Key(7)]
    public long AcquisitionDatetime { get; set; }

    [Key(8)]
    public long LatestVersion { get; set; }
}
