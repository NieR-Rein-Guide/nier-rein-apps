using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserDeckSubWeaponGroup))]
public class EntityIUserDeckSubWeaponGroup
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserDeckCharacterUuid { get; set; }

    [Key(2)]
    public string UserWeaponUuid { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
