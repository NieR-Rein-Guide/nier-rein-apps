using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCostumeEmblemTable : TableBase<EntityMCostumeEmblem> // TypeDefIndex: 11853
    {
        // Fields
        private readonly Func<EntityMCostumeEmblem, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B40C24 Offset: 0x2B40C24 VA: 0x2B40C24
        public EntityMCostumeEmblemTable(EntityMCostumeEmblem[] sortedData):base(sortedData)
        {
            primaryIndexSelector = emblem => emblem.CostumeEmblemAssetId;
        }

        // RVA: 0x2B40D24 Offset: 0x2B40D24 VA: 0x2B40D24
        public EntityMCostumeEmblem FindByCostumeEmblemAssetId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
