using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMPartsTable : TableBase<EntityMParts> // TypeDefIndex: 12063
    {
        // Fields
        private readonly Func<EntityMParts, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C52BE4 Offset: 0x2C52BE4 VA: 0x2C52BE4
        public EntityMPartsTable(EntityMParts[] sortedData):base(sortedData)
        {
            primaryIndexSelector = parts => parts.PartsId;
        }

        // RVA: 0x2C52CE4 Offset: 0x2C52CE4 VA: 0x2C52CE4
        public EntityMParts FindByPartsId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
