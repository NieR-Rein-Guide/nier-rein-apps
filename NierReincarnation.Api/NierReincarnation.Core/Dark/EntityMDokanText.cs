using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_dokan_text")]
    public class EntityMDokanText
    {
        [Key(0)]
        public int DokanTextId { get; set; } // 0x10
        [Key(1)]
        public LanguageType LanguageType { get; set; } // 0x14
        [Key(2)]
        public string Text { get; set; } // 0x18
    }
}