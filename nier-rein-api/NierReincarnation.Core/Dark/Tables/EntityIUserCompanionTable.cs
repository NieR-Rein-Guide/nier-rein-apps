using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserCompanionTable : TableBase<EntityIUserCompanion> // TypeDefIndex: 12487
    {
        // Fields
        private readonly Func<EntityIUserCompanion, (long, string)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2DC77CC Offset: 0x2DC77CC VA: 0x2DC77CC
        public EntityIUserCompanionTable(EntityIUserCompanion[] sortedData):base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.UserCompanionUuid);
        }

        // RVA: 0x2DC78CC Offset: 0x2DC78CC VA: 0x2DC78CC
        public EntityIUserCompanion FindByUserIdAndUserCompanionUuid(ValueTuple<long, string> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
