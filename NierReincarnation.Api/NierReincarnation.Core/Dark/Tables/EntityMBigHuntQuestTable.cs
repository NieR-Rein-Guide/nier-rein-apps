using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBigHuntQuestTable : TableBase<EntityMBigHuntQuest> // TypeDefIndex: 11713
    {
        // Fields
        private readonly Func<EntityMBigHuntQuest, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C47A78 Offset: 0x2C47A78 VA: 0x2C47A78
        public EntityMBigHuntQuestTable(EntityMBigHuntQuest[] sortedData):base(sortedData)
        {
            primaryIndexSelector = quest => quest.BigHuntQuestId;
        }

        // RVA: 0x2C47B78 Offset: 0x2C47B78 VA: 0x2C47B78
        public EntityMBigHuntQuest FindByBigHuntQuestId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
