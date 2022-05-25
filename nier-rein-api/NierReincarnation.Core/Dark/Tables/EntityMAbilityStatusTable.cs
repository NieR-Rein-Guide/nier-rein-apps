using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMAbilityStatusTable : TableBase<EntityMAbilityStatus> // TypeDefIndex: 11547
    {
        // Fields
        private readonly Func<EntityMAbilityStatus, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C40530 Offset: 0x2C40530 VA: 0x2C40530
        public EntityMAbilityStatusTable(EntityMAbilityStatus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = status => status.AbilityStatusId;
        }

        // RVA: 0x2C40630 Offset: 0x2C40630 VA: 0x2C40630
        public EntityMAbilityStatus FindByAbilityStatusId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}
