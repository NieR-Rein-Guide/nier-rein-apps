using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserDeckSubWeaponGroupTable : TableBase<EntityIUserDeckSubWeaponGroup> // TypeDefIndex: 12503
    {
        // Fields
        private readonly Func<EntityIUserDeckSubWeaponGroup, ValueTuple<long, string, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35A5F64 Offset: 0x35A5F64 VA: 0x35A5F64
        public EntityIUserDeckSubWeaponGroupTable(EntityIUserDeckSubWeaponGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.UserDeckCharacterUuid, user.UserWeaponUuid);
        }

        public EntityIUserDeckSubWeaponGroup FindByUserIdAndUserDeckCharacterUuidAndUserWeaponUuid((long,string,string) key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
