using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_quest_auto_orbit")]
public class EntityIUserQuestAutoOrbit
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public QuestType QuestType { get; set; }

    [Key(2)]
    public int ChapterId { get; set; }

    [Key(3)]
    public int QuestId { get; set; }

    [Key(4)]
    public int MaxAutoOrbitCount { get; set; }

    [Key(5)]
    public int ClearedAutoOrbitCount { get; set; }

    [Key(6)]
    public long LastClearDatetime { get; set; }

    [Key(7)]
    public long LatestVersion { get; set; }
}
