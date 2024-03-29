using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserQuestLimitContentStatus))]
public class EntityIUserQuestLimitContentStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int QuestId { get; set; }

    [Key(2)]
    public int LimitContentQuestStatusType { get; set; }

    [Key(3)]
    public int EventQuestChapterId { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
