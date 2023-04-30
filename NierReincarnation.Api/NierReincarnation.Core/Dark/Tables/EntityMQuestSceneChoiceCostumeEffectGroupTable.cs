using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestSceneChoiceCostumeEffectGroupTable : TableBase<EntityMQuestSceneChoiceCostumeEffectGroup>
    {
        private readonly Func<EntityMQuestSceneChoiceCostumeEffectGroup, (int, int)> primaryIndexSelector;
        private readonly Func<EntityMQuestSceneChoiceCostumeEffectGroup, int> secondaryIndexSelector;

        public EntityMQuestSceneChoiceCostumeEffectGroupTable(EntityMQuestSceneChoiceCostumeEffectGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestSceneChoiceCostumeEffectGroupId, element.SortOrder);
            secondaryIndexSelector = element => element.CostumeId;
        }

        public RangeView<EntityMQuestSceneChoiceCostumeEffectGroup> FindByCostumeId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
    }
}
