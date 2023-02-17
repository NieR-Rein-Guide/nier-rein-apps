using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLabyrinthStageTable : TableBase<EntityMEventQuestLabyrinthStage>
    {
        private readonly Func<EntityMEventQuestLabyrinthStage, (int,int)> primaryIndexSelector;
        private readonly Func<EntityMEventQuestLabyrinthStage, int> secondaryIndexSelector;

        public EntityMEventQuestLabyrinthStageTable(EntityMEventQuestLabyrinthStage[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EventQuestChapterId,element.StageOrder);
            secondaryIndexSelector = element => element.EventQuestChapterId;
        }
        
        public EntityMEventQuestLabyrinthStage FindByEventQuestChapterIdAndStageOrder(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

	
        public RangeView<EntityMEventQuestLabyrinthStage> FindByEventQuestChapterId(int key) { return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key); }

    }
}
