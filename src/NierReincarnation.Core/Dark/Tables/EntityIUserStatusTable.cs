using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserStatusTable : TableBase<EntityIUserStatus>
{
    private readonly Func<EntityIUserStatus, long> primaryIndexSelector;

    public EntityIUserStatusTable(EntityIUserStatus[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.UserId;
    }

    public EntityIUserStatus FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
}
