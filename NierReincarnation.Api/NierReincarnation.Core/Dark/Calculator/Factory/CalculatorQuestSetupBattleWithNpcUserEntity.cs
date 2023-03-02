using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Calculator.Factory
{
    public static class CalculatorQuestSetupBattleWithNpcUserEntity
    {
        public static EntityIUserDeck CreateEntityIUserDeck(long userId, DeckType deckType, int userDeckNumber, bool fromNpcTable)
        {
            if (fromNpcTable)
                return GetEntityIUserDeckFromNpcTable(userId, deckType, userDeckNumber);

            return CalculatorUserData.GetEntityIUserDeck(userId, deckType, userDeckNumber);
        }

        private static EntityIUserDeck GetEntityIUserDeckFromNpcTable(long npcId, DeckType deckType, int npcDeckNumber)
        {
            var table = DatabaseDefine.Master.EntityMBattleNpcDeckTable;
            var npcDeck = table.FindByBattleNpcIdAndDeckTypeAndBattleNpcDeckNumber((npcId, deckType, npcDeckNumber));

            return new EntityIUserDeck(npcDeck.BattleNpcId, npcDeck.DeckType, npcDeck.BattleNpcDeckNumber,
                npcDeck.BattleNpcDeckCharacterUuid01, npcDeck.BattleNpcDeckCharacterUuid02, npcDeck.BattleNpcDeckCharacterUuid03,
                npcDeck.Name, npcDeck.Power, 0);
        }
    }
}
