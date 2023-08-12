using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEventQuestDailyGroupTargetChapterTable : TableBase<EntityMEventQuestDailyGroupTargetChapter>
{
    private readonly Func<EntityMEventQuestDailyGroupTargetChapter, (int, int)> primaryIndexSelector;

    public EntityMEventQuestDailyGroupTargetChapterTable(EntityMEventQuestDailyGroupTargetChapter[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.EventQuestDailyGroupTargetChapterId, element.SortOrder);
    }
}
