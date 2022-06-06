using System.Collections.Generic;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Preference;

namespace NierReincarnation.Context
{
    public class DeckContext
    {
        internal DeckContext() { }

        public IEnumerable<DataDeck> GetQuestDecks()
        {
            return CalculatorDeck.EnumerateDeckDataList(PlayerPreference.Instance.ActivePlayer.UserId, DeckType.QUEST);
        }

        public IEnumerable<DataDeckInfo> GetQuestDeckInfo()
        {
            return CalculatorDeck.EnumerateDeckInfo(PlayerPreference.Instance.ActivePlayer.UserId, DeckType.QUEST);
        }

        public DataDeck GetQuestDeck(int deckNumber, DeckType deckType)
        {
            return CalculatorDeck.CreateDataDeck(PlayerPreference.Instance.ActivePlayer.UserId, deckNumber, deckType);
        }
    }
}
