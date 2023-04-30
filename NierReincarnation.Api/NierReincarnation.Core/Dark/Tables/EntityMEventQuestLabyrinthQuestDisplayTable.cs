using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLabyrinthQuestDisplayTable : TableBase<EntityMEventQuestLabyrinthQuestDisplay>
    {
        private readonly Func<EntityMEventQuestLabyrinthQuestDisplay, int> primaryIndexSelector;

        public EntityMEventQuestLabyrinthQuestDisplayTable(EntityMEventQuestLabyrinthQuestDisplay[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestId;
        }

        public bool TryFindByQuestId(int key, out EntityMEventQuestLabyrinthQuestDisplay result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
