using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_apple")]
    public class EntityIUserApple
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string AppleId { get; set; } // 0x18

        [Key(2)]
        public long LatestVersion { get; set; } // 0x20
    }
}
