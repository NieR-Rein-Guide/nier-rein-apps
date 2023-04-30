using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck")]
    public class EntityIUserDeck
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public DeckType DeckType { get; set; } // 0x18

        [Key(2)]
        public int UserDeckNumber { get; set; } // 0x1C

        [Key(3)]
        public string UserDeckCharacterUuid01 { get; set; } // 0x20

        [Key(4)]
        public string UserDeckCharacterUuid02 { get; set; } // 0x28

        [Key(5)]
        public string UserDeckCharacterUuid03 { get; set; } // 0x30

        [Key(6)]
        public string Name { get; set; } // 0x38

        [Key(7)]
        public int Power { get; set; } // 0x40

        [Key(8)]
        public long LatestVersion { get; set; } // 0x48

        public EntityIUserDeck(long UserId, DeckType DeckType, int UserDeckNumber, string UserDeckCharacterUuid01,
            string UserDeckCharacterUuid02, string UserDeckCharacterUuid03, string Name, int Power, long LatestVersion)
        {
            this.UserId = UserId;
            this.DeckType = DeckType;
            this.UserDeckNumber = UserDeckNumber;
            this.UserDeckCharacterUuid01 = UserDeckCharacterUuid01;
            this.UserDeckCharacterUuid02 = UserDeckCharacterUuid02;
            this.UserDeckCharacterUuid03 = UserDeckCharacterUuid03;
            this.Name = Name;
            this.Power = Power;
            this.LatestVersion = LatestVersion;
        }
    }
}
