using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCompanionBaseStatusTable : TableBase<EntityMCompanionBaseStatus> // TypeDefIndex: 11801
    {
        // Fields
        private readonly Func<EntityMCompanionBaseStatus, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B40900 Offset: 0x2B40900 VA: 0x2B40900
        public EntityMCompanionBaseStatusTable(EntityMCompanionBaseStatus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = status => status.CompanionBaseStatusId;
        }

        // RVA: 0x2B40A00 Offset: 0x2B40A00 VA: 0x2B40A00
        public EntityMCompanionBaseStatus FindByCompanionBaseStatusId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
