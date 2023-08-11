using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMLibraryMainQuestGroupTable : TableBase<EntityMLibraryMainQuestGroup>
{
    private readonly Func<EntityMLibraryMainQuestGroup, int> primaryIndexSelector;

    public EntityMLibraryMainQuestGroupTable(EntityMLibraryMainQuestGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.LibraryMainQuestGroupId;
    }
}
