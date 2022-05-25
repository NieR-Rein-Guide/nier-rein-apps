using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserMainQuestProgressStatusTable : TableBase<EntityIUserMainQuestProgressStatus> // TypeDefIndex: 12545
    {
        // Fields
        private readonly Func<EntityIUserMainQuestProgressStatus, long> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35B2B10 Offset: 0x35B2B10 VA: 0x35B2B10
        public EntityIUserMainQuestProgressStatusTable(EntityIUserMainQuestProgressStatus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = status => status.UserId;
        }

        // RVA: 0x35B2C10 Offset: 0x35B2C10 VA: 0x35B2C10
        public EntityIUserMainQuestProgressStatus FindByUserId(long key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
