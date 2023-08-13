using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserTable : TableBase<EntityIUser>
{
    private readonly Func<EntityIUser, long> primaryIndexSelector;

    public EntityIUserTable(EntityIUser[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.UserId;
    }

    public EntityIUser FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
}
