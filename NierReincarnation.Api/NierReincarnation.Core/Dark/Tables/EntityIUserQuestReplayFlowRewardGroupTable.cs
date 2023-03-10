using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserQuestReplayFlowRewardGroupTable : TableBase<EntityIUserQuestReplayFlowRewardGroup>
    {
        private readonly Func<EntityIUserQuestReplayFlowRewardGroup, (long, int)> primaryIndexSelector;

        public EntityIUserQuestReplayFlowRewardGroupTable(EntityIUserQuestReplayFlowRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.QuestReplayFlowRewardGroupId);
        }

        public bool TryFindByUserIdAndQuestReplayFlowRewardGroupId(ValueTuple<long, int> key, out EntityIUserQuestReplayFlowRewardGroup result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result); }
    }
}
