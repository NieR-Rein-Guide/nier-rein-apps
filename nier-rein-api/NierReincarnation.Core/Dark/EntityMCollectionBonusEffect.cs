using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_collection_bonus_effect")]
    public class EntityMCollectionBonusEffect
    {
        [Key(0)]
        public int CollectionBonusEffectId { get; set; } // 0x10
        [Key(1)]
        public int CollectionBonusEffectType { get; set; } // 0x14
        [Key(2)]
        public int Amount00 { get; set; } // 0x18
        [Key(3)]
        public int Amount01 { get; set; } // 0x1C
        [Key(4)]
        public int Amount02 { get; set; } // 0x20
        [Key(5)]
        public int Amount03 { get; set; } // 0x24
        [Key(6)]
        public int Amount04 { get; set; } // 0x28
    }
}