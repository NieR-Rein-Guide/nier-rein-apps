using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_help_page_group")]
    public class EntityMHelpPageGroup
    {
        [Key(0)]
        public int HelpPageGroupId { get; set; } // 0x10

        [Key(1)]
        public int SortOrder { get; set; } // 0x14

        [Key(2)]
        public int HelpPageId { get; set; } // 0x18
    }
}
