using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestDeckMultiRestrictionGroupTable : TableBase<EntityMQuestDeckMultiRestrictionGroup>
{
    private readonly Func<EntityMQuestDeckMultiRestrictionGroup, (int, int)> primaryIndexSelector;
    private readonly Func<EntityMQuestDeckMultiRestrictionGroup, int> secondaryIndexSelector;

    public EntityMQuestDeckMultiRestrictionGroupTable(EntityMQuestDeckMultiRestrictionGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.QuestDeckMultiRestrictionGroupId, element.GroupIndex);
        secondaryIndexSelector = element => (element.QuestDeckMultiRestrictionGroupId);
    }

    public RangeView<EntityMQuestDeckMultiRestrictionGroup> FindByQuestDeckMultiRestrictionGroupId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
}
