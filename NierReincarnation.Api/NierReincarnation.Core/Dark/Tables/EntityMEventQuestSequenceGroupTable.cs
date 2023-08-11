using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEventQuestSequenceGroupTable : TableBase<EntityMEventQuestSequenceGroup>
{
    private readonly Func<EntityMEventQuestSequenceGroup, (int, DifficultyType)> primaryIndexSelector;

    public EntityMEventQuestSequenceGroupTable(EntityMEventQuestSequenceGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.EventQuestSequenceGroupId, element.DifficultyType);
    }

    public EntityMEventQuestSequenceGroup FindByEventQuestSequenceGroupIdAndDifficultyType(ValueTuple<int, DifficultyType> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(int, DifficultyType)>.Default, key);

    public RangeView<EntityMEventQuestSequenceGroup> FindRangeByEventQuestSequenceGroupIdAndDifficultyType(ValueTuple<int, DifficultyType> min, ValueTuple<int, DifficultyType> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, DifficultyType)>.Default, min, max, ascendant);
}
