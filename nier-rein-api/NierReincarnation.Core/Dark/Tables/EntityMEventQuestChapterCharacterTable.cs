using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMEventQuestChapterCharacterTable : TableBase<EntityMEventQuestChapterCharacter> // TypeDefIndex: 11893
    {
        // Fields
        private readonly Func<EntityMEventQuestChapterCharacter, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B43774 Offset: 0x2B43774 VA: 0x2B43774
        public EntityMEventQuestChapterCharacterTable(EntityMEventQuestChapterCharacter[] sortedData):base(sortedData)
        {
            primaryIndexSelector = character => character.EventQuestChapterId;
        }

        // RVA: 0x2B43874 Offset: 0x2B43874 VA: 0x2B43874
        public EntityMEventQuestChapterCharacter FindByEventQuestChapterId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
