using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_awaken_item_acquire")]
    public class EntityMCostumeAwakenItemAcquire
    {
        [Key(0)]
        public int CostumeAwakenItemAcquireId { get; set; } // 0x10

        [Key(1)]
        public PossessionType PossessionType { get; set; } // 0x14

        [Key(2)]
        public int PossessionId { get; set; } // 0x18

        [Key(3)]
        public int Count { get; set; } // 0x1C
    }
}
