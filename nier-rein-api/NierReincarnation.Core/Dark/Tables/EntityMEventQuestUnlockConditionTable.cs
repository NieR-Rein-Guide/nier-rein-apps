using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestUnlockConditionTable : TableBase<EntityMEventQuestUnlockCondition>
    {
        private readonly Func<EntityMEventQuestUnlockCondition, (int,int,int)> primaryIndexSelector;
        private readonly Func<EntityMEventQuestUnlockCondition, (int,int)> secondaryIndexSelector;

        public EntityMEventQuestUnlockConditionTable(EntityMEventQuestUnlockCondition[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EventQuestType,element.CharacterId,element.QuestId);
            secondaryIndexSelector = element => (element.EventQuestType,element.UnlockConditionType);
        }
        
        public EntityMEventQuestUnlockCondition FindByEventQuestTypeAndCharacterIdAndQuestId(ValueTuple<int, int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int,int)>.Default, key); }

	
        public RangeView<EntityMEventQuestUnlockCondition> FindByEventQuestTypeAndUnlockConditionType(ValueTuple<int, int> key) { return FindManyCore(data, secondaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}
