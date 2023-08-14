namespace NierReincarnation.Core.Subsystem.Serval;

public static class DeckServal
{
    public static readonly int MAX_COUNT = 10;
    public static readonly int MIN_COUNT = 1;
    public static readonly int CHARACTER_MAX_COUNT = 3;
    public static readonly int PARTS_MAX_COUNT = 3;
    public static readonly int SUB_WEAPON_MAX_COUNT = 2;

    public static int getSingleDeckNumberByTripleDeckNumber(int userTripleDeckNumber, int deckOrdinalNumber)
    {
        return deckOrdinalNumber + (userTripleDeckNumber * 100);
    }

    public static int getDeckNumberByLimitContentRestrictionDeckGroupNumber(int deckGroupNumber, int questSortOrder)
    {
        return questSortOrder + (deckGroupNumber * 100);
    }
}
