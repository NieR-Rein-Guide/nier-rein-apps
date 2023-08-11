using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestSceneTable : TableBase<EntityMQuestScene>
{
    private readonly Func<EntityMQuestScene, int> primaryIndexSelector;

    public EntityMQuestSceneTable(EntityMQuestScene[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestSceneId;
    }

    public EntityMQuestScene FindByQuestSceneId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);

    public bool TryFindByQuestSceneId(int key, out EntityMQuestScene result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
