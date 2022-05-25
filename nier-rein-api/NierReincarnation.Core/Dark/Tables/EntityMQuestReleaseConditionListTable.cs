using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestReleaseConditionListTable : TableBase<EntityMQuestReleaseConditionList> // TypeDefIndex: 12163
    {
        // Fields
        private readonly Func<EntityMQuestReleaseConditionList, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C5965C Offset: 0x2C5965C VA: 0x2C5965C
        public EntityMQuestReleaseConditionListTable(EntityMQuestReleaseConditionList[] sortedData):base(sortedData)
        {
            primaryIndexSelector = list => list.QuestReleaseConditionListId;
        }

        // RVA: 0x2C5975C Offset: 0x2C5975C VA: 0x2C5975C
        public EntityMQuestReleaseConditionList FindByQuestReleaseConditionListId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
