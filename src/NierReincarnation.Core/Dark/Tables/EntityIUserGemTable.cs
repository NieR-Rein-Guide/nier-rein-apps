using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserGemTable : TableBase<EntityIUserGem>
{
    private readonly Func<EntityIUserGem, long> primaryIndexSelector;

    public EntityIUserGemTable(EntityIUserGem[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.UserId;
    }

    public EntityIUserGem FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
}
