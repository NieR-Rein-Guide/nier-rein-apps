using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCatalogPartsGroupTable : TableBase<EntityMCatalogPartsGroup>
{
    private readonly Func<EntityMCatalogPartsGroup, int> primaryIndexSelector;

    public EntityMCatalogPartsGroupTable(EntityMCatalogPartsGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.PartsGroupId;
    }

    public EntityMCatalogPartsGroup FindByPartsGroupId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
