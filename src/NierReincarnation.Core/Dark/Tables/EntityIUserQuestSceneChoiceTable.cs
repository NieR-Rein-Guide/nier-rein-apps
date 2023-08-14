using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserQuestSceneChoiceTable : TableBase<EntityIUserQuestSceneChoice>
{
    private readonly Func<EntityIUserQuestSceneChoice, (long, int)> primaryIndexSelector;

    public EntityIUserQuestSceneChoiceTable(EntityIUserQuestSceneChoice[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.QuestSceneChoiceGroupingId);
    }

    public bool TryFindByUserIdAndQuestSceneChoiceGroupingId(ValueTuple<long, int> key, out EntityIUserQuestSceneChoice result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result);
}
