using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_event_quest_daily_group_message")]
public class EntityMEventQuestDailyGroupMessage
{
    [Key(0)]
    public int EventQuestDailyGroupMessageId { get; set; }

    [Key(1)]
    public int OddsNumber { get; set; }

    [Key(2)]
    public int Weight { get; set; }

    [Key(3)]
    public int BeforeClearMessageTextId { get; set; }

    [Key(4)]
    public int AfterClearMessageTextId { get; set; }
}
