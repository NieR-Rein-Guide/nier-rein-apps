using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSideStoryQuestLimitContentTable : TableBase<EntityMSideStoryQuestLimitContent>
    {
        private readonly Func<EntityMSideStoryQuestLimitContent, int> primaryIndexSelector;
        private readonly Func<EntityMSideStoryQuestLimitContent, (int,int)> secondaryIndexSelector;

        public EntityMSideStoryQuestLimitContentTable(EntityMSideStoryQuestLimitContent[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SideStoryQuestLimitContentId;
            secondaryIndexSelector = element => (element.EventQuestChapterId,element.DifficultyType);
        }
        
        public EntityMSideStoryQuestLimitContent FindBySideStoryQuestLimitContentId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

	
        public RangeView<EntityMSideStoryQuestLimitContent> FindByEventQuestChapterIdAndDifficultyType(ValueTuple<int, int> key) { return FindManyCore(data, secondaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}
