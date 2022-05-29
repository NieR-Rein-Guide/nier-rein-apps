using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleRentalDeckTable : TableBase<EntityMBattleRentalDeck> // TypeDefIndex: 11689
    {
        // Fields
        private readonly Func<EntityMBattleRentalDeck, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C461C0 Offset: 0x2C461C0 VA: 0x2C461C0
        public EntityMBattleRentalDeckTable(EntityMBattleRentalDeck[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = deck => deck.BattleGroupId;
        }

        // RVA: 0x2C462C0 Offset: 0x2C462C0 VA: 0x2C462C0
        public EntityMBattleRentalDeck FindByBattleGroupId(int key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
