using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserQuestSceneChoiceHistoryTable : TableBase<EntityIUserQuestSceneChoiceHistory>
    {
        private readonly Func<EntityIUserQuestSceneChoiceHistory, (long, int)> primaryIndexSelector;

        public EntityIUserQuestSceneChoiceHistoryTable(EntityIUserQuestSceneChoiceHistory[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.QuestSceneChoiceEffectId);
        }

        public bool TryFindByUserIdAndQuestSceneChoiceEffectId(ValueTuple<long, int> key, out EntityIUserQuestSceneChoiceHistory result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result); }
    }
}