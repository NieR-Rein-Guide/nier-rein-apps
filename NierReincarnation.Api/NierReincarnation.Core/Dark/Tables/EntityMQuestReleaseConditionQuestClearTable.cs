using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestReleaseConditionQuestClearTable : TableBase<EntityMQuestReleaseConditionQuestClear>
    {
        private readonly Func<EntityMQuestReleaseConditionQuestClear, int> primaryIndexSelector;

        public EntityMQuestReleaseConditionQuestClearTable(EntityMQuestReleaseConditionQuestClear[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestReleaseConditionId;
        }

        public EntityMQuestReleaseConditionQuestClear FindByQuestReleaseConditionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
