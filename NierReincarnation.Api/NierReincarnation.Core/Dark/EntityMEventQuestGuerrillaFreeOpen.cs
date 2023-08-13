using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_event_quest_guerrilla_free_open")]
public class EntityMEventQuestGuerrillaFreeOpen
{
    [Key(0)]
    public int EventQuestGuerrillaFreeOpenId { get; set; }

    [Key(1)]
    public int OpenMinutes { get; set; }

    [Key(2)]
    public int DailyOpenMaxCount { get; set; }

    [Key(3)]
    public long StartDatetime { get; set; }

    [Key(4)]
    public long EndDatetime { get; set; }
}
