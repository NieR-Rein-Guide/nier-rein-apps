using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBattleNpcWeaponTable : TableBase<EntityMBattleNpcWeapon> // TypeDefIndex: 11683
    {
        // Fields
        private readonly Func<EntityMBattleNpcWeapon, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C49384 Offset: 0x2C49384 VA: 0x2C49384
        public EntityMBattleNpcWeaponTable(EntityMBattleNpcWeapon[] sortedData):base(sortedData)
        {
            primaryIndexSelector = weapon => (weapon.BattleNpcId, weapon.BattleNpcWeaponUuid);
        }

        // RVA: 0x2C49484 Offset: 0x2C49484 VA: 0x2C49484
        public EntityMBattleNpcWeapon FindByBattleNpcIdAndBattleNpcWeaponUuid(ValueTuple<long, string> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
