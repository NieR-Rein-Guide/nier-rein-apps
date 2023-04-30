using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck_character_dressup_costume")]
    public class EntityIUserDeckCharacterDressupCostume
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string UserDeckCharacterUuid { get; set; } // 0x18

        [Key(2)]
        public int DressupCostumeId { get; set; } // 0x20

        [Key(3)]
        public long LatestVersion { get; set; } // 0x28
    }
}
