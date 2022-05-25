using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestReleaseConditionWeaponAcquisitionTable : TableBase<EntityMQuestReleaseConditionWeaponAcquisition> // TypeDefIndex: 12169
    {
        // Fields
        private readonly Func<EntityMQuestReleaseConditionWeaponAcquisition, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C59CA4 Offset: 0x2C59CA4 VA: 0x2C59CA4
        public EntityMQuestReleaseConditionWeaponAcquisitionTable(EntityMQuestReleaseConditionWeaponAcquisition[] sortedData):
            base(sortedData)
        {
            primaryIndexSelector = acquisition => acquisition.QuestReleaseConditionId;
        }

        // RVA: 0x2C59DA4 Offset: 0x2C59DA4 VA: 0x2C59DA4
        public EntityMQuestReleaseConditionWeaponAcquisition FindByQuestReleaseConditionId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
