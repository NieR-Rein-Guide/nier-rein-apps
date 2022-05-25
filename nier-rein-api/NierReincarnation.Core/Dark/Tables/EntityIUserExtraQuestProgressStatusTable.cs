using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserExtraQuestProgressStatusTable : TableBase<EntityIUserExtraQuestProgressStatus> // TypeDefIndex: 12519
    {
        // Fields
        private readonly Func<EntityIUserExtraQuestProgressStatus, long> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35AD0BC Offset: 0x35AD0BC VA: 0x35AD0BC
        public EntityIUserExtraQuestProgressStatusTable(EntityIUserExtraQuestProgressStatus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = status => status.UserId;
        }

        // RVA: 0x35AD1BC Offset: 0x35AD1BC VA: 0x35AD1BC
        public EntityIUserExtraQuestProgressStatus FindByUserId(long key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
