using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCollectionBonusQuestAssignmentGroupTable : TableBase<EntityMCollectionBonusQuestAssignmentGroup>
{
    private readonly Func<EntityMCollectionBonusQuestAssignmentGroup, (int, int)> primaryIndexSelector;

    public EntityMCollectionBonusQuestAssignmentGroupTable(EntityMCollectionBonusQuestAssignmentGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CollectionBonusQuestAssignmentGroupId, element.CollectionBonusQuestAssignmentId);
    }

    public RangeView<EntityMCollectionBonusQuestAssignmentGroup> FindRangeByCollectionBonusQuestAssignmentGroupIdAndCollectionBonusQuestAssignmentId(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
