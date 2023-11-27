using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCompanionCategory))]
public class EntityMCompanionCategory
{
    [Key(0)]
    public int CompanionCategoryType { get; set; }

    [Key(1)]
    public int EnhancementCostNumericalFunctionId { get; set; }
}
