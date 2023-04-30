using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tip")]
    public class EntityMTip
    {
        [Key(0)]
        public int TipId { get; set; } // 0x10

        [Key(1)]
        public int TitleTipTextId { get; set; } // 0x14

        [Key(2)]
        public int ContentTipTextId { get; set; } // 0x18

        [Key(3)]
        public int TipDisplayConditionGroupId { get; set; } // 0x1C

        [Key(4)]
        public string BackgroundAssetName { get; set; } // 0x20

        [Key(5)]
        public long StartDatetime { get; set; } // 0x28

        [Key(6)]
        public long EndDatetime { get; set; } // 0x30
    }
}
