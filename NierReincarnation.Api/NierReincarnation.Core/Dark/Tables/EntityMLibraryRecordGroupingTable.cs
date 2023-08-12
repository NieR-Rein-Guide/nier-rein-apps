using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMLibraryRecordGroupingTable : TableBase<EntityMLibraryRecordGrouping>
{
    private readonly Func<EntityMLibraryRecordGrouping, LibraryRecordType> primaryIndexSelector;

    public EntityMLibraryRecordGroupingTable(EntityMLibraryRecordGrouping[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.LibraryRecordType;
    }
}
