using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMainQuestChapterTable : TableBase<EntityMMainQuestChapter>
{
    private readonly Func<EntityMMainQuestChapter, int> primaryIndexSelector;

    public EntityMMainQuestChapterTable(EntityMMainQuestChapter[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.MainQuestChapterId;
    }

    public EntityMMainQuestChapter FindByMainQuestChapterId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
