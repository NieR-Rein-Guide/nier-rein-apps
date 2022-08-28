using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gift_text")]
    public class EntityMGiftText
    {
        [Key(0)]
        public int GiftTextId { get; set; } // 0x10
        [Key(1)]
        public int LanguageType { get; set; } // 0x14
        [Key(2)]
        public string Text { get; set; } // 0x18
    }
}