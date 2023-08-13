using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserMainQuestSeasonRouteTable : TableBase<EntityIUserMainQuestSeasonRoute>
{
    private readonly Func<EntityIUserMainQuestSeasonRoute, (long, int)> primaryIndexSelector;

    public EntityIUserMainQuestSeasonRouteTable(EntityIUserMainQuestSeasonRoute[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.MainQuestSeasonId);
    }

    public EntityIUserMainQuestSeasonRoute FindByUserIdAndMainQuestSeasonId(ValueTuple<long, int> key) => FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key);
}
