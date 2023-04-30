using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_companion")]
    public class EntityIUserCompanion
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string UserCompanionUuid { get; set; } // 0x18

        [Key(2)]
        public int CompanionId { get; set; } // 0x20

        [Key(3)]
        public int HeadupDisplayViewId { get; set; } // 0x24

        [Key(4)]
        public int Level { get; set; } // 0x28

        [Key(5)]
        public long AcquisitionDatetime { get; set; } // 0x30

        [Key(6)]
        public long LatestVersion { get; set; } // 0x38
    }
}
