using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeLimitBreakMaterialRarityGroup))]
public class EntityMCostumeLimitBreakMaterialRarityGroup
{
    [Key(0)]
    public int CostumeLimitBreakMaterialRarityGroupId { get; set; }

    [Key(1)]
    public int MaterialId { get; set; }

    [Key(2)]
    public int Count { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }
}
