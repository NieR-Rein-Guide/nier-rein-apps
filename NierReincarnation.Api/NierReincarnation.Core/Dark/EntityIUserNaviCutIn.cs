using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_navi_cut_in")]
    public class EntityIUserNaviCutIn
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10
        [Key(1)]
        public int NaviCutInId { get; set; } // 0x18
        [Key(2)]
        public long PlayDatetime { get; set; } // 0x20
        [Key(3)]
        public long LatestVersion { get; set; } // 0x28
    }
}