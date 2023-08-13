using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestReleaseConditionListTable : TableBase<EntityMQuestReleaseConditionList>
{
    private readonly Func<EntityMQuestReleaseConditionList, int> primaryIndexSelector;

    public EntityMQuestReleaseConditionListTable(EntityMQuestReleaseConditionList[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestReleaseConditionListId;
    }

    public EntityMQuestReleaseConditionList FindByQuestReleaseConditionListId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
