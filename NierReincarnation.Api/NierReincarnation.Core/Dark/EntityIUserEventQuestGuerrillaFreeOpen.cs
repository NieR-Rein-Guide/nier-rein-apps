using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_event_quest_guerrilla_free_open")]
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
