using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestReleaseConditionQuestChallengeTable : TableBase<EntityMQuestReleaseConditionQuestChallenge>
    {
        private readonly Func<EntityMQuestReleaseConditionQuestChallenge, int> primaryIndexSelector;

        public EntityMQuestReleaseConditionQuestChallengeTable(EntityMQuestReleaseConditionQuestChallenge[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestReleaseConditionId;
        }
        
        public EntityMQuestReleaseConditionQuestChallenge FindByQuestReleaseConditionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
