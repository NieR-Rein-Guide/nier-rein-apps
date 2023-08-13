using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMainQuestRouteTable : TableBase<EntityMMainQuestRoute>
{
    private readonly Func<EntityMMainQuestRoute, int> primaryIndexSelector;

    public EntityMMainQuestRouteTable(EntityMMainQuestRoute[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.MainQuestRouteId;
    }

    public EntityMMainQuestRoute FindByMainQuestRouteId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
