using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_possession_auto_convert")]
    public class EntityIUserPossessionAutoConvert
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public PossessionType PossessionType { get; set; } // 0x18

        [Key(2)]
        public int PossessionId { get; set; } // 0x1C

        [Key(3)]
        public int FromCount { get; set; } // 0x20

        [Key(4)]
        public PossessionType ToPossessionType { get; set; } // 0x24

        [Key(5)]
        public int ToPossessionId { get; set; } // 0x28

        [Key(6)]
        public int ToCount { get; set; } // 0x2C

        [Key(7)]
        public long ConvertDatetime { get; set; } // 0x30

        [Key(8)]
        public long LatestVersion { get; set; } // 0x38
    }
}
