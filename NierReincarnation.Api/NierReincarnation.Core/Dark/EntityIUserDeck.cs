using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck")]
    public class EntityIUserDeck
    {
        [Key(0)] // RVA: 0x1DE8884 Offset: 0x1DE8884 VA: 0x1DE8884
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE88C4 Offset: 0x1DE88C4 VA: 0x1DE88C4
        public DeckType DeckType { get; set; }
        [Key(2)] // RVA: 0x1DE8904 Offset: 0x1DE8904 VA: 0x1DE8904
        public int UserDeckNumber { get; set; }
        [Key(3)] // RVA: 0x1DE8944 Offset: 0x1DE8944 VA: 0x1DE8944
        public string UserDeckCharacterUuid01 { get; set; }
        [Key(4)] // RVA: 0x1DE8958 Offset: 0x1DE8958 VA: 0x1DE8958
        public string UserDeckCharacterUuid02 { get; set; }
        [Key(5)] // RVA: 0x1DE896C Offset: 0x1DE896C VA: 0x1DE896C
        public string UserDeckCharacterUuid03 { get; set; }
        [Key(6)] // RVA: 0x1DE8980 Offset: 0x1DE8980 VA: 0x1DE8980
        public string Name { get; set; }
        [Key(7)] // RVA: 0x1DE8994 Offset: 0x1DE8994 VA: 0x1DE8994
        public int Power { get; set; }
        [Key(8)] // RVA: 0x1DE89A8 Offset: 0x1DE89A8 VA: 0x1DE89A8
        public long LatestVersion { get; set; }

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
