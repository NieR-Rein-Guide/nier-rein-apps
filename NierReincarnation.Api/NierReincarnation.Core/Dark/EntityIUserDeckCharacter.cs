using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck_character")]
    public class EntityIUserDeckCharacter
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string UserDeckCharacterUuid { get; set; } // 0x18

        [Key(2)]
        public string UserCostumeUuid { get; set; } // 0x20

        [Key(3)]
        public string MainUserWeaponUuid { get; set; } // 0x28

        [Key(4)]
        public string UserCompanionUuid { get; set; } // 0x30

        [Key(5)]
        public int Power { get; set; } // 0x38

        [Key(6)]
        public string UserThoughtUuid { get; set; } // 0x40

        [Key(7)]
        public long LatestVersion { get; set; } // 0x48
    }
}
