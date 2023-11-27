using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCageMemory))]
public class EntityMCageMemory
{
    [Key(0)]
    public int CageMemoryId { get; set; }

    [Key(1)]
    public int MainQuestSeasonId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }

    [Key(3)]
    public int CageMemoryAssetId { get; set; }
}
