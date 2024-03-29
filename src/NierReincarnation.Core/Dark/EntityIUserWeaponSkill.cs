using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserWeaponSkill))]
public class EntityIUserWeaponSkill
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserWeaponUuid { get; set; }

    [Key(2)]
    public int SlotNumber { get; set; }

    [Key(3)]
    public int Level { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
