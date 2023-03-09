namespace NierReincarnation.Core.Subsystem.Serval
{
    static class DeckServal // TypeDefIndex: 8705
    {
        // Fields
        public static readonly int MAX_COUNT = 10; // 0x0
        public static readonly int MIN_COUNT = 1; // 0x4
        public static readonly int CHARACTER_MAX_COUNT = 3; // 0x8
        public static readonly int PARTS_MAX_COUNT = 3; // 0xC
        public static readonly int SUB_WEAPON_MAX_COUNT = 2; // 0x10

        // Methods

        // RVA: 0x21A2F20 Offset: 0x21A2F20 VA: 0x21A2F20
        public static int getSingleDeckNumberByTripleDeckNumber(int userTripleDeckNumber, int deckOrdinalNumber)
        {
            return deckOrdinalNumber + userTripleDeckNumber * 100;
        }
    }
}
