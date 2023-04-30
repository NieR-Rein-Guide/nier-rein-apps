using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestChapterTable : TableBase<EntityMEventQuestChapter>
    {
        private readonly Func<EntityMEventQuestChapter, int> primaryIndexSelector;

        public EntityMEventQuestChapterTable(EntityMEventQuestChapter[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.EventQuestChapterId;
        }

        public EntityMEventQuestChapter FindByEventQuestChapterId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
