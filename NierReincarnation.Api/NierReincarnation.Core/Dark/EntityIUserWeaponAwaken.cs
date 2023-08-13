using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_weapon_awaken")]
public class EntityIUserWeaponAwaken
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserWeaponUuid { get; set; }

    [Key(2)]
    public long LatestVersion { get; set; }
}
