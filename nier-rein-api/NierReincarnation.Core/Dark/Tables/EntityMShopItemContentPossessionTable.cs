using System;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMShopItemContentPossessionTable : TableBase<EntityMShopItemContentPossession> // TypeDefIndex: 12203
    {
        // Fields
        private readonly Func<EntityMShopItemContentPossession, (int, PossessionType, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C58A04 Offset: 0x2C58A04 VA: 0x2C58A04
        public EntityMShopItemContentPossessionTable(EntityMShopItemContentPossession[] sortedData):base(sortedData)
        {
            primaryIndexSelector = possession => (possession.ShopItemId, possession.PossessionType, possession.PossessionId);
        }
    }
}
