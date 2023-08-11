using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestSceneBattleTable : TableBase<EntityMQuestSceneBattle>
{
    private readonly Func<EntityMQuestSceneBattle, int> primaryIndexSelector;

    public EntityMQuestSceneBattleTable(EntityMQuestSceneBattle[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestSceneId;
    }

    public EntityMQuestSceneBattle FindByQuestSceneId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
