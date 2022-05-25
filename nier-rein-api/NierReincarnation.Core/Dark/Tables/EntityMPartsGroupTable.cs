using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMPartsGroupTable : TableBase<EntityMPartsGroup> // TypeDefIndex: 12049
    {
        // Fields
        private readonly Func<EntityMPartsGroup, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C51AD0 Offset: 0x2C51AD0 VA: 0x2C51AD0
        public EntityMPartsGroupTable(EntityMPartsGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => group.PartsGroupId;
        }

        // RVA: 0x2C51BD0 Offset: 0x2C51BD0 VA: 0x2C51BD0
        public EntityMPartsGroup FindByPartsGroupId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2C51C64 Offset: 0x2C51C64 VA: 0x2C51C64
        public bool TryFindByPartsGroupId(int key, out EntityMPartsGroup result)
        {
            result = null;

            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return false;
                }

            return true;
        }
    }
}
