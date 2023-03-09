using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserMaterialTable : TableBase<EntityIUserMaterial> // TypeDefIndex: 12551
    {
        // Fields
        private readonly Func<EntityIUserMaterial, (long,int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35B3DBC Offset: 0x35B3DBC VA: 0x35B3DBC
        public EntityIUserMaterialTable(EntityIUserMaterial[] sortedData):base(sortedData)
        {
            primaryIndexSelector = material => (material.UserId, material.MaterialId);
        }

        // RVA: 0x35B3EBC Offset: 0x35B3EBC VA: 0x35B3EBC
        public EntityIUserMaterial FindByUserIdAndMaterialId(ValueTuple<long, int> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
