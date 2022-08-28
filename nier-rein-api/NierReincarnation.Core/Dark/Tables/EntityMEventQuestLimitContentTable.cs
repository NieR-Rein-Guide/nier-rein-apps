using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLimitContentTable : TableBase<EntityMEventQuestLimitContent>
    {
        private readonly Func<EntityMEventQuestLimitContent, int> primaryIndexSelector;

        public EntityMEventQuestLimitContentTable(EntityMEventQuestLimitContent[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.EventQuestLimitContentId;
        }
        
        public EntityMEventQuestLimitContent FindByEventQuestLimitContentId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
