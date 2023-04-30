using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_consumable_item")]
    public class EntityIUserConsumableItem
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int ConsumableItemId { get; set; } // 0x18

        [Key(2)]
        public int Count { get; set; } // 0x1C

        [Key(3)]
        public long FirstAcquisitionDatetime { get; set; } // 0x20

        [Key(4)]
        public long LatestVersion { get; set; } // 0x28
    }
}
