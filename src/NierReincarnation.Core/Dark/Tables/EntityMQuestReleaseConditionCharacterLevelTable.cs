using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestReleaseConditionCharacterLevelTable : TableBase<EntityMQuestReleaseConditionCharacterLevel>
{
    private readonly Func<EntityMQuestReleaseConditionCharacterLevel, int> primaryIndexSelector;

    public EntityMQuestReleaseConditionCharacterLevelTable(EntityMQuestReleaseConditionCharacterLevel[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestReleaseConditionId;
    }

    public EntityMQuestReleaseConditionCharacterLevel FindByQuestReleaseConditionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
