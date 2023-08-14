using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_library_record_grouping")]
public class EntityMLibraryRecordGrouping
{
    [Key(0)]
    public LibraryRecordType LibraryRecordType { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int LibraryRecordAssetId { get; set; }
}
