using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestSceneChoiceEffectTable : TableBase<EntityMQuestSceneChoiceEffect>
    {
        private readonly Func<EntityMQuestSceneChoiceEffect, int> primaryIndexSelector;
        private readonly Func<EntityMQuestSceneChoiceEffect, (int, int)> secondaryIndexSelector;

        public EntityMQuestSceneChoiceEffectTable(EntityMQuestSceneChoiceEffect[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.QuestSceneChoiceEffectId;
            secondaryIndexSelector = element => (element.QuestSceneChoiceCostumeEffectGroupId, element.QuestSceneChoiceWeaponEffectGroupId);
        }
    }
}