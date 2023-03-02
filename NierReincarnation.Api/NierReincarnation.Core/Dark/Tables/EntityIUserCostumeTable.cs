using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserCostumeTable : TableBase<EntityIUserCostume> // TypeDefIndex: 12497
    {
        // Fields
        private readonly Func<EntityIUserCostume, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2DC9AE4 Offset: 0x2DC9AE4 VA: 0x2DC9AE4
        public EntityIUserCostumeTable(EntityIUserCostume[] sortedData):base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.UserCostumeUuid);
        }

        // RVA: 0x2DC9BE4 Offset: 0x2DC9BE4 VA: 0x2DC9BE4
        public EntityIUserCostume FindByUserIdAndUserCostumeUuid(ValueTuple<long, string> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2DC9C6C Offset: 0x2DC9C6C VA: 0x2DC9C6C
        public bool TryFindByUserIdAndUserCostumeUuid(ValueTuple<long, string> key, out EntityIUserCostume result)
        {
            result = null;

            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result= element;
                    return true;
                }

            return false;
        }
    }
}
