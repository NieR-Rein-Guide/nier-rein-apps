using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestBonusTable : TableBase<EntityMQuestBonus>
    {
        private readonly Func<EntityMQuestBonus, int> primaryIndexSelector;

        public EntityMQuestBonusTable(EntityMQuestBonus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestBonusId;
        }

        public EntityMQuestBonus FindByQuestBonusId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
