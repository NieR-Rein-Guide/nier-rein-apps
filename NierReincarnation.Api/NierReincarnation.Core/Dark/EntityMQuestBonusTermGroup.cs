using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_bonus_term_group")]
public class EntityMQuestBonusTermGroup
{
    [Key(0)] // RVA: 0x1EA46F4 Offset: 0x1EA46F4 VA: 0x1EA46F4
    public int QuestBonusTermGroupId { get; set; }

    [Key(1)] // RVA: 0x1EA475C Offset: 0x1EA475C VA: 0x1EA475C
    public int SortOrder { get; set; }

    [Key(2)] // RVA: 0x1EA479C Offset: 0x1EA479C VA: 0x1EA479C
    public long StartDatetime { get; set; }

    [Key(3)] // RVA: 0x1EA47B0 Offset: 0x1EA47B0 VA: 0x1EA47B0
    public long EndDatetime { get; set; }
}
