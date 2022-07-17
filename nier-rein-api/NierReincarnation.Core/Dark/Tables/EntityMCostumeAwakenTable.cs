using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeAwakenTable : TableBase<EntityMCostumeAwaken> // TypeDefIndex: 12045
    {
        // Fields
        private readonly Func<EntityMCostumeAwaken, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2D3D9C0 Offset: 0x2D3D9C0 VA: 0x2D3D9C0
        public EntityMCostumeAwakenTable(EntityMCostumeAwaken[] sortedData):base(sortedData)
        {
            primaryIndexSelector = awaken => awaken.CostumeId;
        }

        // RVA: 0x2D3DAC0 Offset: 0x2D3DAC0 VA: 0x2D3DAC0
        public bool TryFindByCostumeId(int key, out EntityMCostumeAwaken result)
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
