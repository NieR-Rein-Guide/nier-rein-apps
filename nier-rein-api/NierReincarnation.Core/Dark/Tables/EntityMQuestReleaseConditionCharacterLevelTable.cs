using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestReleaseConditionCharacterLevelTable : TableBase<EntityMQuestReleaseConditionCharacterLevel> // TypeDefIndex: 12157
    {
        // Fields
        private readonly Func<EntityMQuestReleaseConditionCharacterLevel, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C58FB0 Offset: 0x2C58FB0 VA: 0x2C58FB0
        public EntityMQuestReleaseConditionCharacterLevelTable(EntityMQuestReleaseConditionCharacterLevel[] sortedData):base(sortedData)
        {
            primaryIndexSelector = level => level.QuestReleaseConditionId;
        }

        // RVA: 0x2C590B0 Offset: 0x2C590B0 VA: 0x2C590B0
        public EntityMQuestReleaseConditionCharacterLevel FindByQuestReleaseConditionId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
