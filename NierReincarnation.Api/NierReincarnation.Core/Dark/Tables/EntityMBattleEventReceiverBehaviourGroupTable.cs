using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleEventReceiverBehaviourGroupTable : TableBase<EntityMBattleEventReceiverBehaviourGroup>
{
    private readonly Func<EntityMBattleEventReceiverBehaviourGroup, (int, int)> primaryIndexSelector;

    public EntityMBattleEventReceiverBehaviourGroupTable(EntityMBattleEventReceiverBehaviourGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleEventReceiverBehaviourGroupId, element.ExecuteOrder);
    }

    public RangeView<EntityMBattleEventReceiverBehaviourGroup> FindRangeByBattleEventReceiverBehaviourGroupIdAndExecuteOrder(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
