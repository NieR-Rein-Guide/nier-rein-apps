using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMMainQuestChapterTable : TableBase<EntityMMainQuestChapter> // TypeDefIndex: 11987
    {
        // Fields
        private readonly Func<EntityMMainQuestChapter, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B49940 Offset: 0x2B49940 VA: 0x2B49940
        public EntityMMainQuestChapterTable(EntityMMainQuestChapter[] sortedData):base(sortedData)
        {
            primaryIndexSelector = chapter => chapter.MainQuestChapterId;
        }

        // RVA: 0x2B49A40 Offset: 0x2B49A40 VA: 0x2B49A40
        public EntityMMainQuestChapter FindByMainQuestChapterId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
