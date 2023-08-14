using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_costume_level_bonus_release_status")]
public class EntityIUserCostumeLevelBonusReleaseStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CostumeId { get; set; }

    [Key(2)]
    public int LastReleasedBonusLevel { get; set; }

    [Key(3)]
    public int ConfirmedBonusLevel { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
