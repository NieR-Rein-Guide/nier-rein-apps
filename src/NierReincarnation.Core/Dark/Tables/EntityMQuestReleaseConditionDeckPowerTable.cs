using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestReleaseConditionDeckPowerTable : TableBase<EntityMQuestReleaseConditionDeckPower>
{
    private readonly Func<EntityMQuestReleaseConditionDeckPower, int> primaryIndexSelector;

    public EntityMQuestReleaseConditionDeckPowerTable(EntityMQuestReleaseConditionDeckPower[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestReleaseConditionId;
    }

    public EntityMQuestReleaseConditionDeckPower FindByQuestReleaseConditionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
