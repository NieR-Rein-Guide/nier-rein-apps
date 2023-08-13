using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCompanionCategoryTable : TableBase<EntityMCompanionCategory>
{
    private readonly Func<EntityMCompanionCategory, int> primaryIndexSelector;

    public EntityMCompanionCategoryTable(EntityMCompanionCategory[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CompanionCategoryType;
    }

    public EntityMCompanionCategory FindByCompanionCategoryType(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
