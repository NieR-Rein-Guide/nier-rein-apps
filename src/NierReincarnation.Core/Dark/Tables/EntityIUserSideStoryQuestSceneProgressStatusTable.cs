using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserSideStoryQuestSceneProgressStatusTable : TableBase<EntityIUserSideStoryQuestSceneProgressStatus>
{
    private readonly Func<EntityIUserSideStoryQuestSceneProgressStatus, long> primaryIndexSelector;

    public EntityIUserSideStoryQuestSceneProgressStatusTable(EntityIUserSideStoryQuestSceneProgressStatus[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.UserId;
    }

    public EntityIUserSideStoryQuestSceneProgressStatus FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
}
