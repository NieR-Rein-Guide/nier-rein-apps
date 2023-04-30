using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_facebook")]
    public class EntityIUserFacebook
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public long FacebookId { get; set; } // 0x18

        [Key(2)]
        public long LatestVersion { get; set; } // 0x20
    }
}
