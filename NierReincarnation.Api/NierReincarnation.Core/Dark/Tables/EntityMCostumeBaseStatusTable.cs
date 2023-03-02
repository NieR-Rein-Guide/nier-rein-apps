using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCostumeBaseStatusTable : TableBase<EntityMCostumeBaseStatus> // TypeDefIndex: 11839
    {
        // Fields
        private readonly Func<EntityMCostumeBaseStatus, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B433A8 Offset: 0x2B433A8 VA: 0x2B433A8
        public EntityMCostumeBaseStatusTable(EntityMCostumeBaseStatus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = status => status.CostumeBaseStatusId;
        }

        // RVA: 0x2B434A8 Offset: 0x2B434A8 VA: 0x2B434A8
        public EntityMCostumeBaseStatus FindByCostumeBaseStatusId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}
