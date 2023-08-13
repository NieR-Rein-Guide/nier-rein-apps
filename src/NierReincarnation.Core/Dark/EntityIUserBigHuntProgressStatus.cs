using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_big_hunt_progress_status")]
public class EntityIUserBigHuntProgressStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CurrentBigHuntBossQuestId { get; set; }

    [Key(2)]
    public int CurrentBigHuntQuestId { get; set; }

    [Key(3)]
    public int CurrentQuestSceneId { get; set; }

    [Key(4)]
    public bool IsDryRun { get; set; }

    [Key(5)]
    public long LatestVersion { get; set; }
}
