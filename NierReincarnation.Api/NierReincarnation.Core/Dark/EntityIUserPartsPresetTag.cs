using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_parts_preset_tag")]
    public class EntityIUserPartsPresetTag
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10
        [Key(1)]
        public int UserPartsPresetTagNumber { get; set; } // 0x18
        [Key(2)]
        public string Name { get; set; } // 0x20
        [Key(3)]
        public long LatestVersion { get; set; } // 0x28
    }
}