using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserWeaponTable : TableBase<EntityIUserWeapon> // TypeDefIndex: 12615
    {
        // Fields
        private readonly Func<EntityIUserWeapon, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C3E848 Offset: 0x2C3E848 VA: 0x2C3E848
        public EntityIUserWeaponTable(EntityIUserWeapon[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.UserWeaponUuid);
        }

        // RVA: 0x2C3E948 Offset: 0x2C3E948 VA: 0x2C3E948
        public EntityIUserWeapon FindByUserIdAndUserWeaponUuid(ValueTuple<long, string> key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2C3E9D0 Offset: 0x2C3E9D0 VA: 0x2C3E9D0
        public bool TryFindByUserIdAndUserWeaponUuid(ValueTuple<long, string> key, out EntityIUserWeapon result)
        {
            result = null;

            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
