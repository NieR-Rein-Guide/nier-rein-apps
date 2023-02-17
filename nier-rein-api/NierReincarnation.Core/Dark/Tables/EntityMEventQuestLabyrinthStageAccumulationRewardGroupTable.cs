using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLabyrinthStageAccumulationRewardGroupTable : TableBase<EntityMEventQuestLabyrinthStageAccumulationRewardGroup>
    {
        private readonly Func<EntityMEventQuestLabyrinthStageAccumulationRewardGroup, (int,int)> primaryIndexSelector;
        private readonly Func<EntityMEventQuestLabyrinthStageAccumulationRewardGroup, int> secondaryIndexSelector;

        public EntityMEventQuestLabyrinthStageAccumulationRewardGroupTable(EntityMEventQuestLabyrinthStageAccumulationRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EventQuestLabyrinthStageAccumulationRewardGroupId,element.QuestMissionClearCount);
            secondaryIndexSelector = element => element.EventQuestLabyrinthStageAccumulationRewardGroupId;
        }
        
        public RangeView<EntityMEventQuestLabyrinthStageAccumulationRewardGroup> FindByEventQuestLabyrinthStageAccumulationRewardGroupId(int key) { return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key); }

    }
}
