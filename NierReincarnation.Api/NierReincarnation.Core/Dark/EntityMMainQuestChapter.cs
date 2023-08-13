﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_main_quest_chapter")]
public class EntityMMainQuestChapter
{
    [Key(0)]
    public int MainQuestChapterId { get; set; }

    [Key(1)]
    public int MainQuestRouteId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }

    [Key(3)]
    public int MainQuestSequenceGroupId { get; set; }

    [Key(4)]
    public int PortalCageCharacterGroupId { get; set; }

    [Key(5)]
    public long StartDatetime { get; set; }
}
