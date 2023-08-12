using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Dark;

// CUSTOM: DataDeck with less information necessary to be loaded
public class DataDeckInfo
{
    public DeckType DeckType { get; set; }

    public int UserDeckNumber { get; set; }

    public string Name { get; set; }

    public DataDeckActorInfo[] UserDeckActors { get; set; }

    public bool IsEmpty => UserDeckActors[0]?.Costume == null;

    public bool IsMinimal => UserDeckActors[1] == null &&
                             UserDeckActors[2] == null &&
                            (UserDeckActors[0]?.IsMinimal ?? true);

    public DataDeckInfo(DeckType deckType, int userDeckNumber) : this()
    {
        DeckType = deckType;
        UserDeckNumber = userDeckNumber;
    }

    public DataDeckInfo()
    {
        UserDeckActors = new DataDeckActorInfo[3];
    }

    public override string ToString()
    {
        if (!string.IsNullOrEmpty(Name))
            return Name;

        switch (DeckType)
        {
            case DeckType.QUEST:
                return UserInterfaceTextKey.Deck.kTypeQuest.Localize() + $"{UserDeckNumber}";

            case DeckType.BIG_HUNT:
                return UserInterfaceTextKey.Deck.kTypeBigHunt.Localize() + $"{UserDeckNumber}";

            case DeckType.RESTRICTED_QUEST:
                return UserInterfaceTextKey.Deck.kRestrictionDeck.Localize() + $"{UserDeckNumber}";

            case DeckType.RESTRICTED_LIMIT_CONTENT_QUEST:
                var quests = CalculatorLimitContent.CreateDataLimitContentCharacters().OrderBy(x => x.SortOrder).ToArray();
                var questIndex = (UserDeckNumber - 101) / 100;

                return UserInterfaceTextKey.Deck.kRestrictionDeck.Localize() + $" {quests[questIndex].Costume.CharacterName}{UserDeckNumber % 100}";
        }

        return string.Empty;
    }
}
