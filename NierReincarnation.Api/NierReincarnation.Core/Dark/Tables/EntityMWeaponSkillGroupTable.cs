using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMWeaponSkillGroupTable : TableBase<EntityMWeaponSkillGroup> // TypeDefIndex: 12435
    {
        // Fields
        private readonly Func<EntityMWeaponSkillGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BACC50 Offset: 0x2BACC50 VA: 0x2BACC50
        public EntityMWeaponSkillGroupTable(EntityMWeaponSkillGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.WeaponSkillGroupId, group.SlotNumber);
        }

        // RVA: 0x2BACD50 Offset: 0x2BACD50 VA: 0x2BACD50
        public EntityMWeaponSkillGroup FindByWeaponSkillGroupIdAndSlotNumber(ValueTuple<int, int> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2BACDD0 Offset: 0x2BACDD0 VA: 0x2BACDD0
        public RangeView<EntityMWeaponSkillGroup> FindRangeByWeaponSkillGroupIdAndSlotNumber(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
