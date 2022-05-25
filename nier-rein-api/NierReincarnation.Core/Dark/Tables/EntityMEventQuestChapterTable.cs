using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    // Dark.Tables.EntityMEventQuestChapterTable
    public class EntityMEventQuestChapterTable : TableBase<EntityMEventQuestChapter>
    {
        // 0x18
        private readonly Func<EntityMEventQuestChapter, int> primaryIndexSelector;

        public EntityMEventQuestChapterTable(EntityMEventQuestChapter[] sortedData) : base(sortedData)
        {
            primaryIndexSelector= element => element.EventQuestChapterId;
        }

        public EntityMEventQuestChapter FindByEventQuestChapterId(int key)
        {
            foreach(var element in data)
                if (key == primaryIndexSelector(element))
                    return element;

            return null;
        }
    }
}
