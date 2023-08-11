using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_companion_category")]
    public class EntityMCompanionCategory
    {
        [Key(0)] // RVA: 0x1DDB648 Offset: 0x1DDB648 VA: 0x1DDB648
        public int CompanionCategoryType { get; set; }

        [Key(1)] // RVA: 0x1DDB688 Offset: 0x1DDB688 VA: 0x1DDB688
        public int EnhancementCostNumericalFunctionId { get; set; }
    }
}
