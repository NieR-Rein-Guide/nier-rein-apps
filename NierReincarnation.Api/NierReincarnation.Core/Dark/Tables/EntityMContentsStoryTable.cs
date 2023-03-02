using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMContentsStoryTable : TableBase<EntityMContentsStory>
    {
        private readonly Func<EntityMContentsStory, int> primaryIndexSelector;

        public EntityMContentsStoryTable(EntityMContentsStory[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ContentsStoryId;
        }
        
        public EntityMContentsStory FindByContentsStoryId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
