using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLabyrinthQuestEffectDisplayTable : TableBase<EntityMEventQuestLabyrinthQuestEffectDisplay>
    {
        private readonly Func<EntityMEventQuestLabyrinthQuestEffectDisplay, (int, int)> primaryIndexSelector;
        private readonly Func<EntityMEventQuestLabyrinthQuestEffectDisplay, int> secondaryIndexSelector;

        public EntityMEventQuestLabyrinthQuestEffectDisplayTable(EntityMEventQuestLabyrinthQuestEffectDisplay[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestId, element.SortOrder);
            secondaryIndexSelector = element => element.QuestId;
        }

        public RangeView<EntityMEventQuestLabyrinthQuestEffectDisplay> FindByQuestId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
    }
}
