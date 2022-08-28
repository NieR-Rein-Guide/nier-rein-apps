using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_navi_cut_in_text")]
    public class EntityMNaviCutInText
    {
        [Key(0)]
        public int NaviCutInTextId { get; set; } // 0x10
        [Key(1)]
        public int LanguageType { get; set; } // 0x14
        [Key(2)]
        public string Text { get; set; } // 0x18
    }
}