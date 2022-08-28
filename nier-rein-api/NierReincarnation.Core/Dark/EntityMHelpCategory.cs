using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_help_category")]
    public class EntityMHelpCategory
    {
        [Key(0)]
        public int HelpCategoryId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public int TitleTextAssetId { get; set; } // 0x18
        [Key(3)]
        public bool IsHiddenOnList { get; set; } // 0x1C
    }
}