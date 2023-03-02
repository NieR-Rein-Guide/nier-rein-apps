using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserProfileTable : TableBase<EntityIUserProfile> // TypeDefIndex: 12577
    {
        // Fields
        private readonly Func<EntityIUserProfile, long> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35B9CB8 Offset: 0x35B9CB8 VA: 0x35B9CB8
        public EntityIUserProfileTable(EntityIUserProfile[] sortedData):base(sortedData)
        {
            primaryIndexSelector = profile => profile.UserId;
        }

        // RVA: 0x35B9DB8 Offset: 0x35B9DB8 VA: 0x35B9DB8
        public EntityIUserProfile FindByUserId(long key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
