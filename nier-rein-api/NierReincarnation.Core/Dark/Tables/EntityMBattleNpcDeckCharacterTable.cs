using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBattleNpcDeckCharacterTable : TableBase<EntityMBattleNpcDeckCharacter> // TypeDefIndex: 11647
    {
        // Fields
        private readonly Func<EntityMBattleNpcDeckCharacter, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C46FC0 Offset: 0x2C46FC0 VA: 0x2C46FC0
        public EntityMBattleNpcDeckCharacterTable(EntityMBattleNpcDeckCharacter[] sortedData):base(sortedData)
        {
            primaryIndexSelector = character => (character.BattleNpcId, character.BattleNpcDeckCharacterUuid);
        }

        // RVA: 0x2C470C0 Offset: 0x2C470C0 VA: 0x2C470C0
        public EntityMBattleNpcDeckCharacter FindByBattleNpcIdAndBattleNpcDeckCharacterUuid(ValueTuple<long, string> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
