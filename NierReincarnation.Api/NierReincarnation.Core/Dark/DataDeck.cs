using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark;

public class DataDeck // TypeDefIndex: 9010
{
    public DeckType DeckType { get; set; }

    public int UserDeckNumber { get; set; }

    public string Name { get; set; }

    public int Power { get; set; }

    public DataDeckActor[] UserDeckActors { get; set; }

    public bool IsEmpty => UserDeckActors == null ||
                           UserDeckActors.Length == 0 ||
                           UserDeckActors[0].MainWeapon == null;

    // Methods

    // RVA: 0x234353C Offset: 0x234353C VA: 0x234353C
    public DataDeck(DeckType deckType, int userDeckNumber) : this()
    {
        DeckType = deckType;
        UserDeckNumber = userDeckNumber;
    }

    // RVA: 0x2343570 Offset: 0x2343570 VA: 0x2343570
    public DataDeck()
    {
        UserDeckActors = new DataDeckActor[DeckServal.CHARACTER_MAX_COUNT];
    }
}
