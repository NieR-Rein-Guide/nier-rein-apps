using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCompanionAbilityGroupTable : TableBase<EntityMCompanionAbilityGroup> // TypeDefIndex: 11797
    {
        // Fields
        private readonly Func<EntityMCompanionAbilityGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B403FC Offset: 0x2B403FC VA: 0x2B403FC
        public EntityMCompanionAbilityGroupTable(EntityMCompanionAbilityGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.CompanionAbilityGroupId, group.SlotNumber);
        }

        // RVA: 0x2B404FC Offset: 0x2B404FC VA: 0x2B404FC
        public EntityMCompanionAbilityGroup FindByCompanionAbilityGroupIdAndSlotNumber(ValueTuple<int, int> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
