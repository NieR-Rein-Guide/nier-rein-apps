using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMLibraryMainQuestStoryTable : TableBase<EntityMLibraryMainQuestStory>
    {
        private readonly Func<EntityMLibraryMainQuestStory, (int,int)> primaryIndexSelector;
        private readonly Func<EntityMLibraryMainQuestStory, int> secondaryIndexSelector;

        public EntityMLibraryMainQuestStoryTable(EntityMLibraryMainQuestStory[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.LibraryMainQuestGroupId,element.SortOrder);
            secondaryIndexSelector = element => element.LibraryMainQuestGroupId;
        }
        
        public RangeView<EntityMLibraryMainQuestStory> FindByLibraryMainQuestGroupId(int key) { return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key); }

    }
}
