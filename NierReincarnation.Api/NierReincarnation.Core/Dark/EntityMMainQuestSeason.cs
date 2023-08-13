using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_main_quest_season")]
public class EntityMMainQuestSeason
{
    [Key(0)]
    public int MainQuestSeasonId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }
}
