using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserCostumeLevelBonusReleaseStatusTable : TableBase<EntityIUserCostumeLevelBonusReleaseStatus>
{
    private readonly Func<EntityIUserCostumeLevelBonusReleaseStatus, (long, int)> primaryIndexSelector;

    public EntityIUserCostumeLevelBonusReleaseStatusTable(EntityIUserCostumeLevelBonusReleaseStatus[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.CostumeId);
    }

    public bool TryFindByUserIdAndCostumeId(ValueTuple<long, int> key, out EntityIUserCostumeLevelBonusReleaseStatus result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result);
}
