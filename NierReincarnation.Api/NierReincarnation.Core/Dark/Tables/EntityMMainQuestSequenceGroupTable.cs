using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMainQuestSequenceGroupTable : TableBase<EntityMMainQuestSequenceGroup>
{
    private readonly Func<EntityMMainQuestSequenceGroup, (int, DifficultyType)> primaryIndexSelector;

    public EntityMMainQuestSequenceGroupTable(EntityMMainQuestSequenceGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.MainQuestSequenceGroupId, element.DifficultyType);
    }

    public EntityMMainQuestSequenceGroup FindByMainQuestSequenceGroupIdAndDifficultyType(ValueTuple<int, DifficultyType> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(int, DifficultyType)>.Default, key);
}
