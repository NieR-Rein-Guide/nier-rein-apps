using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserCostumeLotteryEffectPendingTable : TableBase<EntityIUserCostumeLotteryEffectPending>
{
    private readonly Func<EntityIUserCostumeLotteryEffectPending, (long, string)> primaryIndexSelector;

    public EntityIUserCostumeLotteryEffectPendingTable(EntityIUserCostumeLotteryEffectPending[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.UserCostumeUuid);
    }

    public bool TryFindByUserIdAndUserCostumeUuid(ValueTuple<long, string> key, out EntityIUserCostumeLotteryEffectPending result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, string)>.Default, key, out result);
}
