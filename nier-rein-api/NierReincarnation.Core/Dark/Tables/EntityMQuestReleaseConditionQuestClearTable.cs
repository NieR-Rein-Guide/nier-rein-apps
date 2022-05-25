using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestReleaseConditionQuestClearTable : TableBase<EntityMQuestReleaseConditionQuestClear> // TypeDefIndex: 12165
    {
        // Fields
        private readonly Func<EntityMQuestReleaseConditionQuestClear, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C59874 Offset: 0x2C59874 VA: 0x2C59874
        public EntityMQuestReleaseConditionQuestClearTable(EntityMQuestReleaseConditionQuestClear[] sortedData):base(sortedData)
        {
            primaryIndexSelector = clear => clear.QuestReleaseConditionId;
        }

        // RVA: 0x2C59974 Offset: 0x2C59974 VA: 0x2C59974
        public EntityMQuestReleaseConditionQuestClear FindByQuestReleaseConditionId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
