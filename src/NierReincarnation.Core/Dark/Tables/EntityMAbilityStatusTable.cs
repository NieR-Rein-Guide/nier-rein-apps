using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMAbilityStatusTable : TableBase<EntityMAbilityStatus>
{
    private readonly Func<EntityMAbilityStatus, int> primaryIndexSelector;

    public EntityMAbilityStatusTable(EntityMAbilityStatus[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.AbilityStatusId;
    }

    public EntityMAbilityStatus FindByAbilityStatusId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
