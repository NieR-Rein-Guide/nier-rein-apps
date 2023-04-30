using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_parts_preset")]
    public class EntityIUserPartsPreset
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int UserPartsPresetNumber { get; set; } // 0x18

        [Key(2)]
        public string UserPartsUuid01 { get; set; } // 0x20

        [Key(3)]
        public string UserPartsUuid02 { get; set; } // 0x28

        [Key(4)]
        public string UserPartsUuid03 { get; set; } // 0x30

        [Key(5)]
        public string Name { get; set; } // 0x38

        [Key(6)]
        public int UserPartsPresetTagNumber { get; set; } // 0x40

        [Key(7)]
        public long LatestVersion { get; set; } // 0x48
    }
}
