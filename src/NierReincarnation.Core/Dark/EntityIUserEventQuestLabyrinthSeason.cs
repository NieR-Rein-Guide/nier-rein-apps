using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserEventQuestLabyrinthSeason))]
public class EntityIUserEventQuestLabyrinthSeason
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int EventQuestChapterId { get; set; }

    [Key(2)]
    public int LastJoinSeasonNumber { get; set; }

    [Key(3)]
    public int LastSeasonRewardReceivedSeasonNumber { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
