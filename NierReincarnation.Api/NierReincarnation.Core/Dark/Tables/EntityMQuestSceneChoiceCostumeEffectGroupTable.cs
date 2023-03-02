using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestSceneChoiceCostumeEffectGroupTable : TableBase<EntityMQuestSceneChoiceCostumeEffectGroup>
    {
        private readonly Func<EntityMQuestSceneChoiceCostumeEffectGroup, (int,int)> primaryIndexSelector;
        private readonly Func<EntityMQuestSceneChoiceCostumeEffectGroup, int> secondaryIndexSelector;

        public EntityMQuestSceneChoiceCostumeEffectGroupTable(EntityMQuestSceneChoiceCostumeEffectGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestSceneChoiceCostumeEffectGroupId,element.SortOrder);
            secondaryIndexSelector = element => element.CostumeId;
        }
        
        public RangeView<EntityMQuestSceneChoiceCostumeEffectGroup> FindByCostumeId(int key) { return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key); }

    }
}
