using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestMissionTable : TableBase<EntityMQuestMission>
{
    private readonly Func<EntityMQuestMission, int> primaryIndexSelector;

    public EntityMQuestMissionTable(EntityMQuestMission[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestMissionId;
    }

    public EntityMQuestMission FindByQuestMissionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
