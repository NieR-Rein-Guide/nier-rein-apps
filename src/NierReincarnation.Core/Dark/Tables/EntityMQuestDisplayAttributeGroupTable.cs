using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestDisplayAttributeGroupTable : TableBase<EntityMQuestDisplayAttributeGroup>
{
    private readonly Func<EntityMQuestDisplayAttributeGroup, (int, int)> primaryIndexSelector;

    public EntityMQuestDisplayAttributeGroupTable(EntityMQuestDisplayAttributeGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.QuestDisplayAttributeGroupId, element.SortOrder);
    }
}
