using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEventQuestDisplayItemGroupTable : TableBase<EntityMEventQuestDisplayItemGroup>
{
    private readonly Func<EntityMEventQuestDisplayItemGroup, (int, int)> primaryIndexSelector;

    public EntityMEventQuestDisplayItemGroupTable(EntityMEventQuestDisplayItemGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.EventQuestDisplayItemGroupId, element.SortOrder);
    }
}
