using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_library_record_grouping")]
    public class EntityMLibraryRecordGrouping
    {
        [Key(0)]
        public LibraryRecordType LibraryRecordType { get; set; } // 0x10

        [Key(1)]
        public int SortOrder { get; set; } // 0x14

        [Key(2)]
        public int LibraryRecordAssetId { get; set; } // 0x18
    }
}
