﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMainQuestRoute))]
public class EntityMMainQuestRoute
{
    [Key(0)]
    public int MainQuestRouteId { get; set; }

    [Key(1)]
    public int MainQuestSeasonId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }

    [Key(3)]
    public int CharacterId { get; set; }
}
