using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_help_item")]
    public class EntityMHelpItem
    {
        [Key(0)]
        public int HelpItemId { get; set; } // 0x10

        [Key(1)]
        public int HelpCategoryId { get; set; } // 0x14

        [Key(2)]
        public int SortOrder { get; set; } // 0x18

        [Key(3)]
        public int TotalPageCount { get; set; } // 0x1C

        [Key(4)]
        public int TitleTextAssetId { get; set; } // 0x20

        [Key(5)]
        public string AssetName { get; set; } // 0x28

        [Key(6)]
        public bool IsHiddenOnList { get; set; } // 0x30
    }
}
