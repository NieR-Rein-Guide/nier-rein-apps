using System;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCostumeRarityTable : TableBase<EntityMCostumeRarity> // TypeDefIndex: 11865
    {
        // Fields
        private readonly Func<EntityMCostumeRarity, RarityType> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B45048 Offset: 0x2B45048 VA: 0x2B45048
        public EntityMCostumeRarityTable(EntityMCostumeRarity[] sortedData):base(sortedData)
        {
            primaryIndexSelector = rarity => rarity.RarityType;
        }

        // RVA: 0x2B45148 Offset: 0x2B45148 VA: 0x2B45148
        public EntityMCostumeRarity FindByRarityType(RarityType key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
