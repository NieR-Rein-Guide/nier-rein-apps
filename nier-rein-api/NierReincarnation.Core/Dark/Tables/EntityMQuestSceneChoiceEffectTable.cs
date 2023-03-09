using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestSceneChoiceEffectTable : TableBase<EntityMQuestSceneChoiceEffect>
    {
        private readonly Func<EntityMQuestSceneChoiceEffect, int> primaryIndexSelector;
        private readonly Func<EntityMQuestSceneChoiceEffect, int> secondaryIndexSelector;
        private readonly Func<EntityMQuestSceneChoiceEffect, int> secondaryIndex1Selector;

        public EntityMQuestSceneChoiceEffectTable(EntityMQuestSceneChoiceEffect[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestSceneChoiceEffectId;
            secondaryIndexSelector = element => element.QuestSceneChoiceCostumeEffectGroupId;
            secondaryIndex1Selector= element => element.QuestSceneChoiceWeaponEffectGroupId;
        }

        public RangeView<EntityMQuestSceneChoiceEffect> FindByQuestSceneChoiceCostumeEffectGroupId(int key)
        {
            return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
        }
    }
}
