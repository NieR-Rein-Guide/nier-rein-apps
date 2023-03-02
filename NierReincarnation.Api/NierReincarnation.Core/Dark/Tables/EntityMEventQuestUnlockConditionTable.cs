using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestUnlockConditionTable : TableBase<EntityMEventQuestUnlockCondition>
    {
        private readonly Func<EntityMEventQuestUnlockCondition, (EventQuestType, int,int)> primaryIndexSelector;
        private readonly Func<EntityMEventQuestUnlockCondition, (EventQuestType, UnlockConditionType)> secondaryIndexSelector;

        public EntityMEventQuestUnlockConditionTable(EntityMEventQuestUnlockCondition[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EventQuestType,element.CharacterId,element.QuestId);
            secondaryIndexSelector = element => (element.EventQuestType,element.UnlockConditionType);
        }

        public EntityMEventQuestUnlockCondition FindByEventQuestTypeAndCharacterIdAndQuestId(ValueTuple<EventQuestType, int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(EventQuestType, int,int)>.Default, key); }

        public RangeView<EntityMEventQuestUnlockCondition> FindByEventQuestTypeAndUnlockConditionType(ValueTuple<EventQuestType, UnlockConditionType> key) { return FindManyCore(data, secondaryIndexSelector, Comparer<(EventQuestType, UnlockConditionType)>.Default, key); }

    }
}