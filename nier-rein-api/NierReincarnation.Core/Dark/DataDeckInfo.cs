﻿using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Dark
{
    // CUSTOM: DataDeck with less information necessary to be loaded
    public class DataDeckInfo
    {
        // 0x10
        public DeckType DeckType { get; set; }
        // 0x14
        public int UserDeckNumber { get; set; }
        // 0x18
        public string Name { get; set; }

        public DataDeckInfo(DeckType deckType, int userDeckNumber) : this()
        {
            DeckType = deckType;
            UserDeckNumber = userDeckNumber;
        }

        public DataDeckInfo()
        { }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name))
                return Name;

            switch (DeckType)
            {
                case DeckType.QUEST:
                    return UserInterfaceTextKey.Deck.kTypeQuest.Localize() + $"{UserDeckNumber}";

                case DeckType.BIG_HUNT:
                    return UserInterfaceTextKey.Deck.kTypeBigHunt.Localize() + $"{UserDeckNumber - 100}";
            }

            return string.Empty;
        }
    }
}
