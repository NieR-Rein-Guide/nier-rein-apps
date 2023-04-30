using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck_parts_group")]
    public class EntityIUserDeckPartsGroup
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string UserDeckCharacterUuid { get; set; } // 0x18

        [Key(2)]
        public string UserPartsUuid { get; set; } // 0x20

        [Key(3)]
        public int SortOrder { get; set; } // 0x28

        [Key(4)]
        public long LatestVersion { get; set; } // 0x30
    }
}
