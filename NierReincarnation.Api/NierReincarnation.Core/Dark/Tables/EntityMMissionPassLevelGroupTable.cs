using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMMissionPassLevelGroupTable : TableBase<EntityMMissionPassLevelGroup>
    {
        private readonly Func<EntityMMissionPassLevelGroup, (int, int)> primaryIndexSelector;
        private readonly Func<EntityMMissionPassLevelGroup, int> secondaryIndexSelector;

        public EntityMMissionPassLevelGroupTable(EntityMMissionPassLevelGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.MissionPassLevelGroupId, element.Level);
            secondaryIndexSelector = element => element.MissionPassLevelGroupId;
        }

        public EntityMMissionPassLevelGroup FindByMissionPassLevelGroupIdAndLevel(ValueTuple<int, int> key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key); }

        public RangeView<EntityMMissionPassLevelGroup> FindByMissionPassLevelGroupId(int key)
        { return FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key); }
    }
}
