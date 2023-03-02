using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestReleaseConditionDeckPowerTable : TableBase<EntityMQuestReleaseConditionDeckPower> // TypeDefIndex: 12159
    {
        // Fields
        private readonly Func<EntityMQuestReleaseConditionDeckPower, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C591C8 Offset: 0x2C591C8 VA: 0x2C591C8
        public EntityMQuestReleaseConditionDeckPowerTable(EntityMQuestReleaseConditionDeckPower[] sortedData):base(sortedData)
        {
            primaryIndexSelector = power => power.QuestReleaseConditionId;
        }

        // RVA: 0x2C592C8 Offset: 0x2C592C8 VA: 0x2C592C8
        public EntityMQuestReleaseConditionDeckPower FindByQuestReleaseConditionId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
