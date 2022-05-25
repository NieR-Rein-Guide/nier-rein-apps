using System;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBattleNpcDeckTable : TableBase<EntityMBattleNpcDeck> // TypeDefIndex: 11655
    {
        // Fields
        private readonly Func<EntityMBattleNpcDeck, ValueTuple<long, DeckType, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C47848 Offset: 0x2C47848 VA: 0x2C47848
        public EntityMBattleNpcDeckTable(EntityMBattleNpcDeck[] sortedData):base(sortedData)
        {
            primaryIndexSelector = deck => (deck.BattleNpcId, deck.DeckType, deck.BattleNpcDeckNumber);
        }

        // RVA: 0x2C47948 Offset: 0x2C47948 VA: 0x2C47948
        public EntityMBattleNpcDeck FindByBattleNpcIdAndDeckTypeAndBattleNpcDeckNumber(ValueTuple<long, DeckType, int> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
