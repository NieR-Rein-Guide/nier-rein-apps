using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestBonusEffectGroupTable : TableBase<EntityMQuestBonusEffectGroup>
    {
        private readonly Func<EntityMQuestBonusEffectGroup, (int, int)> primaryIndexSelector;

        public EntityMQuestBonusEffectGroupTable(EntityMQuestBonusEffectGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestBonusEffectGroupId, element.SortOrder);
        }

        public RangeView<EntityMQuestBonusEffectGroup> FindRangeByQuestBonusEffectGroupIdAndSortOrder(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
            FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
    }
}
