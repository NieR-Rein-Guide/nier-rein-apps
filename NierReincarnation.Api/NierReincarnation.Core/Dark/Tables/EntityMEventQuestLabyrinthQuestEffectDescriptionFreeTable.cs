using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLabyrinthQuestEffectDescriptionFreeTable : TableBase<EntityMEventQuestLabyrinthQuestEffectDescriptionFree>
    {
        private readonly Func<EntityMEventQuestLabyrinthQuestEffectDescriptionFree, int> primaryIndexSelector;

        public EntityMEventQuestLabyrinthQuestEffectDescriptionFreeTable(EntityMEventQuestLabyrinthQuestEffectDescriptionFree[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.EventQuestLabyrinthQuestEffectDescriptionId;
        }

        public EntityMEventQuestLabyrinthQuestEffectDescriptionFree FindByEventQuestLabyrinthQuestEffectDescriptionId(int key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
