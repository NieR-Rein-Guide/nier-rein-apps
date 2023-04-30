using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLabyrinthRewardGroupTable : TableBase<EntityMEventQuestLabyrinthRewardGroup>
    {
        private readonly Func<EntityMEventQuestLabyrinthRewardGroup, (int, int)> primaryIndexSelector;
        private readonly Func<EntityMEventQuestLabyrinthRewardGroup, int> secondaryIndexSelector;

        public EntityMEventQuestLabyrinthRewardGroupTable(EntityMEventQuestLabyrinthRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EventQuestLabyrinthRewardGroupId, element.SortOrder);
            secondaryIndexSelector = element => element.EventQuestLabyrinthRewardGroupId;
        }

        public RangeView<EntityMEventQuestLabyrinthRewardGroup> FindByEventQuestLabyrinthRewardGroupId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
    }
}
