using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestTowerRewardGroupTable : TableBase<EntityMEventQuestTowerRewardGroup>
    {
        private readonly Func<EntityMEventQuestTowerRewardGroup, (int, int)> primaryIndexSelector;

        public EntityMEventQuestTowerRewardGroupTable(EntityMEventQuestTowerRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EventQuestTowerRewardGroupId, element.SortOrder);
        }

        public EntityMEventQuestTowerRewardGroup FindByEventQuestTowerRewardGroupIdAndSortOrder(ValueTuple<int, int> key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key);
    }
}
