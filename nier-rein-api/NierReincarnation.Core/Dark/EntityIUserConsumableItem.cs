using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_consumable_item")]
    public class EntityIUserConsumableItem
    {
        [Key(0)] // RVA: 0x1DE4FE0 Offset: 0x1DE4FE0 VA: 0x1DE4FE0
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE5020 Offset: 0x1DE5020 VA: 0x1DE5020
        public int ConsumableItemId { get; set; }
        [Key(2)] // RVA: 0x1DE5060 Offset: 0x1DE5060 VA: 0x1DE5060
        public int Count { get; set; }
        [Key(3)] // RVA: 0x1DE5074 Offset: 0x1DE5074 VA: 0x1DE5074
        public long FirstAcquisitionDatetime { get; set; }
        [Key(4)] // RVA: 0x1DE5088 Offset: 0x1DE5088 VA: 0x1DE5088
        public long LatestVersion { get; set; }
	}
}
