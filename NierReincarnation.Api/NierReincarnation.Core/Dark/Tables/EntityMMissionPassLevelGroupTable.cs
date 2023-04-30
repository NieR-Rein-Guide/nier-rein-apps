using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public EntityMMissionPassLevelGroup FindByMissionPassLevelGroupIdAndLevel(ValueTuple<int, int> key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key);

        public RangeView<EntityMMissionPassLevelGroup> FindByMissionPassLevelGroupId(int key)
        {
            var result = data
                .Where(x => x.MissionPassLevelGroupId == key)
                .ToArray();

            return new RangeView<EntityMMissionPassLevelGroup>(result, 0, result.Length, true);
        }
    }
}
