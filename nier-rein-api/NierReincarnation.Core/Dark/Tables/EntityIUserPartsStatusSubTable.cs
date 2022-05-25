using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserPartsStatusSubTable : TableBase<EntityIUserPartsStatusSub> // TypeDefIndex: 12569
    {
        // Fields
        private readonly Func<EntityIUserPartsStatusSub, ValueTuple<long, string, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35B435C Offset: 0x35B435C VA: 0x35B435C
        public EntityIUserPartsStatusSubTable(EntityIUserPartsStatusSub[] sortedData):base(sortedData)
        {
            primaryIndexSelector = sub => (sub.UserId, sub.UserPartsUuid, sub.StatusIndex);
        }

        public EntityIUserPartsStatusSub FindByUserIdAndUserPartsUuidAndStatusIndex((long, string, int) key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
