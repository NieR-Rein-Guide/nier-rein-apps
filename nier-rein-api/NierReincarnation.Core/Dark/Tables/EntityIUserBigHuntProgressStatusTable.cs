using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserBigHuntProgressStatusTable : TableBase<EntityIUserBigHuntProgressStatus> // TypeDefIndex: 12467
    {
        // Fields
        private readonly Func<EntityIUserBigHuntProgressStatus, long> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2DC42DC Offset: 0x2DC42DC VA: 0x2DC42DC
        public EntityIUserBigHuntProgressStatusTable(EntityIUserBigHuntProgressStatus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = status => status.UserId;
        }

        // RVA: 0x2DC43DC Offset: 0x2DC43DC VA: 0x2DC43DC
        public EntityIUserBigHuntProgressStatus FindByUserId(long key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
