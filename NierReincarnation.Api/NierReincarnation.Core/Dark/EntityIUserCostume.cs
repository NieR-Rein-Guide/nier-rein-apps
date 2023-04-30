using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_costume")]
    public class EntityIUserCostume
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string UserCostumeUuid { get; set; } // 0x18

        [Key(2)]
        public int CostumeId { get; set; } // 0x20

        [Key(3)]
        public int LimitBreakCount { get; set; } // 0x24

        [Key(4)]
        public int Level { get; set; } // 0x28

        [Key(5)]
        public int Exp { get; set; } // 0x2C

        [Key(6)]
        public int HeadupDisplayViewId { get; set; } // 0x30

        [Key(7)]
        public long AcquisitionDatetime { get; set; } // 0x38

        [Key(8)]
        public int AwakenCount { get; set; } // 0x40

        [Key(9)]
        public long LatestVersion { get; set; } // 0x48
    }
}
