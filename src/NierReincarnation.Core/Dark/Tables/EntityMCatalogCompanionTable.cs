using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCatalogCompanionTable : TableBase<EntityMCatalogCompanion>
{
    private readonly Func<EntityMCatalogCompanion, int> primaryIndexSelector;

    public EntityMCatalogCompanionTable(EntityMCatalogCompanion[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CompanionId;
    }

    public EntityMCatalogCompanion FindByCompanionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
