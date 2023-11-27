﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestScenePictureBookReplaceTable : TableBase<EntityMQuestScenePictureBookReplace>
{
    private readonly Func<EntityMQuestScenePictureBookReplace, int> primaryIndexSelector;

    public EntityMQuestScenePictureBookReplaceTable(EntityMQuestScenePictureBookReplace[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestSceneId;
    }

    public bool TryFindByQuestSceneId(int key, out EntityMQuestScenePictureBookReplace result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
