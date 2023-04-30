using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_profile")]
    public class EntityIUserProfile
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string Name { get; set; } // 0x18

        [Key(2)]
        public long NameUpdateDatetime { get; set; } // 0x20

        [Key(3)]
        public string Message { get; set; } // 0x28

        [Key(4)]
        public long MessageUpdateDatetime { get; set; } // 0x30

        [Key(5)]
        public int FavoriteCostumeId { get; set; } // 0x38

        [Key(6)]
        public long FavoriteCostumeIdUpdateDatetime { get; set; } // 0x40

        [Key(7)]
        public long LatestVersion { get; set; } // 0x48
    }
}
