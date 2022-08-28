using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_navi_cut_in")]
    public class EntityMNaviCutIn
    {
        [Key(0)]
        public int NaviCutInId { get; set; } // 0x10
        [Key(1)]
        public int RelatedCutInFunctionType { get; set; } // 0x14
        [Key(2)]
        public int SortOrder { get; set; } // 0x18
        [Key(3)]
        public long StartDatetime { get; set; } // 0x20
        [Key(4)]
        public long EndDatetime { get; set; } // 0x28
        [Key(5)]
        public int NaviCutInContentGroupId { get; set; } // 0x30
        [Key(6)]
        public int RelatedCutInFunctionValue { get; set; } // 0x34
    }
}