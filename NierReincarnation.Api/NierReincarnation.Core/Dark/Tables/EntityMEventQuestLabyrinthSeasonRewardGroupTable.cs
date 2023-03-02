using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLabyrinthSeasonRewardGroupTable : TableBase<EntityMEventQuestLabyrinthSeasonRewardGroup>
    {
        private readonly Func<EntityMEventQuestLabyrinthSeasonRewardGroup, (int,int)> primaryIndexSelector;
        private readonly Func<EntityMEventQuestLabyrinthSeasonRewardGroup, int> secondaryIndexSelector;

        public EntityMEventQuestLabyrinthSeasonRewardGroupTable(EntityMEventQuestLabyrinthSeasonRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EventQuestLabyrinthSeasonRewardGroupId,element.HeadQuestId);
            secondaryIndexSelector = element => element.EventQuestLabyrinthSeasonRewardGroupId;
        }

        public EntityMEventQuestLabyrinthSeasonRewardGroup FindByEventQuestLabyrinthSeasonRewardGroupIdAndHeadQuestId(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

        public RangeView<EntityMEventQuestLabyrinthSeasonRewardGroup> FindByEventQuestLabyrinthSeasonRewardGroupId(int key) { return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key); }
    }
}
