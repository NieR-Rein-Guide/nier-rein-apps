using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestDeckRestrictionGroupUnlockTable : TableBase<EntityMQuestDeckRestrictionGroupUnlock>
    {
        private readonly Func<EntityMQuestDeckRestrictionGroupUnlock, int> primaryIndexSelector;

        public EntityMQuestDeckRestrictionGroupUnlockTable(EntityMQuestDeckRestrictionGroupUnlock[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestDeckRestrictionGroupId;
        }
        
        public EntityMQuestDeckRestrictionGroupUnlock FindByQuestDeckRestrictionGroupId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
