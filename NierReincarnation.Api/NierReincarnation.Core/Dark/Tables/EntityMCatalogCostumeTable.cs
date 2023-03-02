using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCatalogCostumeTable : TableBase<EntityMCatalogCostume> // TypeDefIndex: 11735
    {
        // Fields
        private readonly Func<EntityMCatalogCostume, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C490F4 Offset: 0x2C490F4 VA: 0x2C490F4
        public EntityMCatalogCostumeTable(EntityMCatalogCostume[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = costume => costume.CostumeId;
        }

        // RVA: 0x2C491F4 Offset: 0x2C491F4 VA: 0x2C491F4
        public bool TryFindByCostumeId(int key, out EntityMCatalogCostume result)
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
