using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserQuestMission))]
public class EntityIUserQuestMission
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int QuestId { get; set; }

    [Key(2)]
    public int QuestMissionId { get; set; }

    [Key(3)]
    public int ProgressValue { get; set; }

    [Key(4)]
    public bool IsClear { get; set; }

    [Key(5)]
    public long LatestClearDatetime { get; set; }

    [Key(6)]
    public long LatestVersion { get; set; }
}
