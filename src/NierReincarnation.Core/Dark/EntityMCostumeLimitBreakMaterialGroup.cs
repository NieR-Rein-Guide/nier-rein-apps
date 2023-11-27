using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeLimitBreakMaterialGroup))]
public class EntityMCostumeLimitBreakMaterialGroup
{
    [Key(0)]
    public int CostumeLimitBreakMaterialGroupId { get; set; }

    [Key(1)]
    public int MaterialId { get; set; }

    [Key(2)]
    public int Count { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }

    [Key(4)]
    public int CostumeOverflowExchangePossessionGroupId { get; set; }
}
