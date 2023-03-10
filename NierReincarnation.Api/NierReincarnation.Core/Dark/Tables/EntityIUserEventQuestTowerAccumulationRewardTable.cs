using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserEventQuestTowerAccumulationRewardTable : TableBase<EntityIUserEventQuestTowerAccumulationReward>
    {
        private readonly Func<EntityIUserEventQuestTowerAccumulationReward, (long, int)> primaryIndexSelector;

        public EntityIUserEventQuestTowerAccumulationRewardTable(EntityIUserEventQuestTowerAccumulationReward[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.EventQuestChapterId);
        }

        public EntityIUserEventQuestTowerAccumulationReward FindByUserIdAndEventQuestChapterId(ValueTuple<long, int> key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key); }
    }
}
