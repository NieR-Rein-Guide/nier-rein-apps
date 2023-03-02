using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Calculator.Database
{
    public static class CalculatorUserData
    {
        public static EntityIUserDeck GetEntityIUserDeck(long userId, DeckType deckType, int userDeckNumber)
        {
            var table = DatabaseDefine.User.EntityIUserDeckTable;
            return table.FindByUserIdAndDeckTypeAndUserDeckNumber((userId, deckType, userDeckNumber));
        }
    }
}
