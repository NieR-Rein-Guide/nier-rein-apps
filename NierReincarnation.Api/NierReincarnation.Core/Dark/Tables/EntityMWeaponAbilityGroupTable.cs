using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMWeaponAbilityGroupTable : TableBase<EntityMWeaponAbilityGroup> // TypeDefIndex: 12413
    {
        // Fields
        private readonly Func<EntityMWeaponAbilityGroup, (int,int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BAAFEC Offset: 0x2BAAFEC VA: 0x2BAAFEC
        public EntityMWeaponAbilityGroupTable(EntityMWeaponAbilityGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.WeaponAbilityGroupId, group.SlotNumber);
        }

        // RVA: 0x2BAB0EC Offset: 0x2BAB0EC VA: 0x2BAB0EC
        public EntityMWeaponAbilityGroup FindByWeaponAbilityGroupIdAndSlotNumber((int, int) key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }

        public RangeView<EntityMWeaponAbilityGroup> FindRangeByWeaponAbilityGroupIdAndSlotNumber((int, int) min, (int, int) max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
