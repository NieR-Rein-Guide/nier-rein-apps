using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark;

public class DataDeck
{
    public DeckType DeckType { get; set; }

    public int UserDeckNumber { get; set; }

    public string Name { get; set; }

    public int Power { get; set; }

    public DataDeckActor[] UserDeckActors { get; set; }

    public bool IsEmpty => UserDeckActors == null ||
                           UserDeckActors.Length == 0 ||
                           UserDeckActors[0].MainWeapon == null;

    public DataDeck(DeckType deckType, int userDeckNumber) : this()
    {
        DeckType = deckType;
        UserDeckNumber = userDeckNumber;
    }

    public DataDeck()
    {
        UserDeckActors = new DataDeckActor[DeckServal.CHARACTER_MAX_COUNT];
    }
}
