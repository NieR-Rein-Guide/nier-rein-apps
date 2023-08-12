using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMLibraryMainQuestGroupTable : TableBase<EntityMLibraryMainQuestGroup>
{
    private readonly Func<EntityMLibraryMainQuestGroup, int> primaryIndexSelector;

    public EntityMLibraryMainQuestGroupTable(EntityMLibraryMainQuestGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.LibraryMainQuestGroupId;
    }
}
