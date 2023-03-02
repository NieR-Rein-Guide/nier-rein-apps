using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestReleaseConditionUserLevelTable : TableBase<EntityMQuestReleaseConditionUserLevel> // TypeDefIndex: 12167
    {
        // Fields
        private readonly Func<EntityMQuestReleaseConditionUserLevel, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C59A8C Offset: 0x2C59A8C VA: 0x2C59A8C
        public EntityMQuestReleaseConditionUserLevelTable(EntityMQuestReleaseConditionUserLevel[] sortedData):base(sortedData)
        {
            primaryIndexSelector = level => level.QuestReleaseConditionId;
        }

        // RVA: 0x2C59B8C Offset: 0x2C59B8C VA: 0x2C59B8C
        public EntityMQuestReleaseConditionUserLevel FindByQuestReleaseConditionId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
