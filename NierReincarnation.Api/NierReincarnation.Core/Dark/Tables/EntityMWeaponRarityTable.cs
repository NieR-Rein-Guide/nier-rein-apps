using System;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMWeaponRarityTable : TableBase<EntityMWeaponRarity> // TypeDefIndex: 12431
    {
        // Fields
        private readonly Func<EntityMWeaponRarity, RarityType> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BAC78C Offset: 0x2BAC78C VA: 0x2BAC78C
        public EntityMWeaponRarityTable(EntityMWeaponRarity[] sortedData):base(sortedData)
        {
            primaryIndexSelector = rarity => rarity.RarityType;
        }

        // RVA: 0x2BAC88C Offset: 0x2BAC88C VA: 0x2BAC88C
        public EntityMWeaponRarity FindByRarityType(RarityType key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
