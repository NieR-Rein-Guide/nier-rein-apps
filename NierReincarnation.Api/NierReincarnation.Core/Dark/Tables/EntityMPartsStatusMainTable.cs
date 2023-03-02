using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMPartsStatusMainTable : TableBase<EntityMPartsStatusMain> // TypeDefIndex: 12061
    {
        // Fields
        private readonly Func<EntityMPartsStatusMain, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C52924 Offset: 0x2C52924 VA: 0x2C52924
        public EntityMPartsStatusMainTable(EntityMPartsStatusMain[] sortedData):base(sortedData)
        {
            primaryIndexSelector = main => main.PartsStatusMainId;
        }

        // RVA: 0x2C52A24 Offset: 0x2C52A24 VA: 0x2C52A24
        public EntityMPartsStatusMain FindByPartsStatusMainId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2C52AB8 Offset: 0x2C52AB8 VA: 0x2C52AB8
        public bool TryFindByPartsStatusMainId(int key, out EntityMPartsStatusMain result)
        {
            result = null;

            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
