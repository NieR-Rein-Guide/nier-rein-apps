using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleBigHuntDamageThresholdGroupTable : TableBase<EntityMBattleBigHuntDamageThresholdGroup>
    {
        private readonly Func<EntityMBattleBigHuntDamageThresholdGroup, (int, int)> primaryIndexSelector;

        public EntityMBattleBigHuntDamageThresholdGroupTable(EntityMBattleBigHuntDamageThresholdGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.KnockDownDamageThresholdGroupId, element.KnockDownDamageThresholdGroupOrder);
        }

        public RangeView<EntityMBattleBigHuntDamageThresholdGroup> FindRangeByKnockDownDamageThresholdGroupIdAndKnockDownDamageThresholdGroupOrder(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
            FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
    }
}
