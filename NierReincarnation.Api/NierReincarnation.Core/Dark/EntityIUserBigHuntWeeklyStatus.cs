using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_big_hunt_weekly_status")]
public class EntityIUserBigHuntWeeklyStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public long BigHuntWeeklyVersion { get; set; }

    [Key(2)]
    public bool IsReceivedWeeklyReward { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
