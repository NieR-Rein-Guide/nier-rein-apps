using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck_character")]
    public class EntityIUserDeckCharacter
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public string UserDeckCharacterUuid { get; set; }

        [Key(2)]
        public string UserCostumeUuid { get; set; }

        [Key(3)]
        public string MainUserWeaponUuid { get; set; }

        [Key(4)]
        public string UserCompanionUuid { get; set; }

        [Key(5)]
        public int Power { get; set; }

        [Key(6)]
        public string UserThoughtUuid { get; set; }

        [Key(7)]
        public long LatestVersion { get; set; }
    }
}
