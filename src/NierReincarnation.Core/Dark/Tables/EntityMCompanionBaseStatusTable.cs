using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCompanionBaseStatusTable : TableBase<EntityMCompanionBaseStatus>
{
    private readonly Func<EntityMCompanionBaseStatus, int> primaryIndexSelector;

    public EntityMCompanionBaseStatusTable(EntityMCompanionBaseStatus[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CompanionBaseStatusId;
    }

    public EntityMCompanionBaseStatus FindByCompanionBaseStatusId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
