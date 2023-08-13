using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_companion_category")]
public class EntityMCompanionCategory
{
    [Key(0)]
    public int CompanionCategoryType { get; set; }

    [Key(1)]
    public int EnhancementCostNumericalFunctionId { get; set; }
}
