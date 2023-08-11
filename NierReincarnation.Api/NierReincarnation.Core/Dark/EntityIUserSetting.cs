using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_setting")]
    public class EntityIUserSetting
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public bool IsNotifyPurchaseAlert { get; set; }

        [Key(2)]
        public long LatestVersion { get; set; }
    }
}
