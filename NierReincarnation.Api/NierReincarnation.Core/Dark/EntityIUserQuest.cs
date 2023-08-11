using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_quest")]
public class EntityIUserQuest
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int QuestId { get; set; }

    [Key(2)]
    public int QuestStateType { get; set; }

    [Key(3)]
    public bool IsBattleOnly { get; set; }

    [Key(4)]
    public long LatestStartDatetime { get; set; }

    [Key(5)]
    public int ClearCount { get; set; }

    [Key(6)]
    public int DailyClearCount { get; set; }

    [Key(7)]
    public long LastClearDatetime { get; set; }

    [Key(8)]
    public int ShortestClearFrames { get; set; }

    [Key(9)]
    public long LatestVersion { get; set; }
}
