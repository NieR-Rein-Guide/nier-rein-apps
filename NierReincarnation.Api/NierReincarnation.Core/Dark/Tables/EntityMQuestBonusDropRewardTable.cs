using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestBonusDropRewardTable : TableBase<EntityMQuestBonusDropReward>
    {
        private readonly Func<EntityMQuestBonusDropReward, int> primaryIndexSelector;

        public EntityMQuestBonusDropRewardTable(EntityMQuestBonusDropReward[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestBonusEffectId;
        }

        public EntityMQuestBonusDropReward FindByQuestBonusEffectId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
