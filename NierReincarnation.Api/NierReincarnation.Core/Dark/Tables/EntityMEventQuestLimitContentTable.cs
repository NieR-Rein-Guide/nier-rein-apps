using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLimitContentTable : TableBase<EntityMEventQuestLimitContent>
    {
        private readonly Func<EntityMEventQuestLimitContent, int> primaryIndexSelector;

        public EntityMEventQuestLimitContentTable(EntityMEventQuestLimitContent[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.EventQuestLimitContentId;
        }

        public EntityMEventQuestLimitContent FindByEventQuestLimitContentId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
