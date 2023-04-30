using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_setting")]
    public class EntityIUserSetting
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public bool IsNotifyPurchaseAlert { get; set; } // 0x18

        [Key(2)]
        public long LatestVersion { get; set; } // 0x20
    }
}
