using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_triple_deck")]
    public class EntityIUserTripleDeck
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public DeckType DeckType { get; set; } // 0x18

        [Key(2)]
        public int UserDeckNumber { get; set; } // 0x1C

        [Key(3)]
        public string Name { get; set; } // 0x20

        [Key(4)]
        public int DeckNumber01 { get; set; } // 0x28

        [Key(5)]
        public int DeckNumber02 { get; set; } // 0x2C

        [Key(6)]
        public int DeckNumber03 { get; set; } // 0x30

        [Key(7)]
        public long LatestVersion { get; set; } // 0x38
    }
}
