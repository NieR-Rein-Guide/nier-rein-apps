using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_pvp_weekly_result")]
public class EntityIUserPvpWeeklyResult
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public long PvpWeeklyVersion { get; set; }

    [Key(2)]
    public int PvpSeasonId { get; set; }

    [Key(3)]
    public int GroupId { get; set; }

    [Key(4)]
    public int FinalPoint { get; set; }

    [Key(5)]
    public int FinalRank { get; set; }

    [Key(6)]
    public long LatestVersion { get; set; }
}
