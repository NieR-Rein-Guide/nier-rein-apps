using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserTable : TableBase<EntityIUser> // TypeDefIndex: 12601
    {
        // Fields
        private readonly Func<EntityIUser, long> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35BB600 Offset: 0x35BB600 VA: 0x35BB600
        public EntityIUserTable(EntityIUser[] sortedData):base(sortedData)
        {
            primaryIndexSelector = user => user.UserId;
        }

        // RVA: 0x35BB700 Offset: 0x35BB700 VA: 0x35BB700
        public EntityIUser FindByUserId(long key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
