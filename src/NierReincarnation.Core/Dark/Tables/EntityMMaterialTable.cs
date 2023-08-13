using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMaterialTable : TableBase<EntityMMaterial>
{
    private readonly Func<EntityMMaterial, int> primaryIndexSelector;

    public EntityMMaterialTable(EntityMMaterial[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.MaterialId;
    }

    public EntityMMaterial FindByMaterialId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
