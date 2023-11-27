using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserEventQuestGuerrillaFreeOpen))]
public class EntityIUserEventQuestGuerrillaFreeOpen
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public long StartDatetime { get; set; }

    [Key(2)]
    public int OpenMinutes { get; set; }

    [Key(3)]
    public int DailyOpenedCount { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
