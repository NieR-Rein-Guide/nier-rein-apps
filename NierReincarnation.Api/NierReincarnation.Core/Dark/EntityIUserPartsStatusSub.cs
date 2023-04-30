using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_parts_status_sub")]
    public class EntityIUserPartsStatusSub
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string UserPartsUuid { get; set; } // 0x18

        [Key(2)]
        public int StatusIndex { get; set; } // 0x20

        [Key(3)]
        public int PartsStatusSubLotteryId { get; set; } // 0x24

        [Key(4)]
        public int Level { get; set; } // 0x28

        [Key(5)]
        public StatusKindType StatusKindType { get; set; } // 0x2C

        [Key(6)]
        public StatusCalculationType StatusCalculationType { get; set; } // 0x30

        [Key(7)]
        public int StatusChangeValue { get; set; } // 0x34

        [Key(8)]
        public long LatestVersion { get; set; } // 0x38
    }
}
