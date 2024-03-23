﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestFirstClearRewardSwitchTable : TableBase<EntityMQuestFirstClearRewardSwitch>
{
    private readonly Func<EntityMQuestFirstClearRewardSwitch, int> primaryIndexSelector;

    public EntityMQuestFirstClearRewardSwitchTable(EntityMQuestFirstClearRewardSwitch[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestId;
    }

    public bool TryFindByQuestId(int key, out EntityMQuestFirstClearRewardSwitch result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
