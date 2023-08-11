using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_main_quest_chapter")]
public class EntityMMainQuestChapter
{
    [Key(0)] // RVA: 0x1DDBBA4 Offset: 0x1DDBBA4 VA: 0x1DDBBA4
    public int MainQuestChapterId { get; set; }

    [Key(1)] // RVA: 0x1DDBBE4 Offset: 0x1DDBBE4 VA: 0x1DDBBE4
    public int MainQuestRouteId { get; set; }

    [Key(2)] // RVA: 0x1DDBBF8 Offset: 0x1DDBBF8 VA: 0x1DDBBF8
    public int SortOrder { get; set; }

    [Key(3)] // RVA: 0x1DDBC0C Offset: 0x1DDBC0C VA: 0x1DDBC0C
    public int MainQuestSequenceGroupId { get; set; }

    [Key(4)] // RVA: 0x1DDBC20 Offset: 0x1DDBC20 VA: 0x1DDBC20
    public int PortalCageCharacterGroupId { get; set; }

    [Key(5)] // RVA: 0x1DDBC34 Offset: 0x1DDBC34 VA: 0x1DDBC34
    public long StartDatetime { get; set; }
}
