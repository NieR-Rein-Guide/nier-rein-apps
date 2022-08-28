using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestBonusAbilityTable : TableBase<EntityMQuestBonusAbility>
    {
        private readonly Func<EntityMQuestBonusAbility, int> primaryIndexSelector;

        public EntityMQuestBonusAbilityTable(EntityMQuestBonusAbility[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestBonusEffectId;
        }
        
        public EntityMQuestBonusAbility FindByQuestBonusEffectId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
