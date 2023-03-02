using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserStatusTable : TableBase<EntityIUserStatus> // TypeDefIndex: 12599
    {
        // Fields
        private readonly Func<EntityIUserStatus, long> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35BAF48 Offset: 0x35BAF48 VA: 0x35BAF48
        public EntityIUserStatusTable(EntityIUserStatus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = status => status.UserId;
        }

        // RVA: 0x35BB048 Offset: 0x35BB048 VA: 0x35BB048
        public EntityIUserStatus FindByUserId(long key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
