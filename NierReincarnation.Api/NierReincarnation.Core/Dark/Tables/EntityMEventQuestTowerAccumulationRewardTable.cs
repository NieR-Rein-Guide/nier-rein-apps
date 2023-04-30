using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestTowerAccumulationRewardTable : TableBase<EntityMEventQuestTowerAccumulationReward>
    {
        private readonly Func<EntityMEventQuestTowerAccumulationReward, int> primaryIndexSelector;

        public EntityMEventQuestTowerAccumulationRewardTable(EntityMEventQuestTowerAccumulationReward[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.EventQuestChapterId;
        }

        public EntityMEventQuestTowerAccumulationReward FindByEventQuestChapterId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
