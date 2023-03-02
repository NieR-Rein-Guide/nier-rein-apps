using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserWeaponAbilityTable : TableBase<EntityIUserWeaponAbility> // TypeDefIndex: 12607
    {
        // Fields
        private readonly Func<EntityIUserWeaponAbility, ValueTuple<long, string, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C3CBAC Offset: 0x2C3CBAC VA: 0x2C3CBAC
        public EntityIUserWeaponAbilityTable(EntityIUserWeaponAbility[] sortedData):base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.UserWeaponUuid, user.SlotNumber);
        }

        public EntityIUserWeaponAbility FindByUserIdAndUserWeaponUuidAndSlotNumber(ValueTuple<long, string, int> key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2C3CCAC Offset: 0x2C3CCAC VA: 0x2C3CCAC
        public bool TryFindByUserIdAndUserWeaponUuidAndSlotNumber(ValueTuple<long, string, int> key, out EntityIUserWeaponAbility result)
        {
            result = null;

            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
