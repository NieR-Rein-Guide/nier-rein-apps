using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMaterialSaleObtainPossessionTable : TableBase<EntityMMaterialSaleObtainPossession>
{
    private readonly Func<EntityMMaterialSaleObtainPossession, (int, int)> primaryIndexSelector;

    public EntityMMaterialSaleObtainPossessionTable(EntityMMaterialSaleObtainPossession[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.MaterialSaleObtainPossessionId, element.SortOrder);
    }
}
