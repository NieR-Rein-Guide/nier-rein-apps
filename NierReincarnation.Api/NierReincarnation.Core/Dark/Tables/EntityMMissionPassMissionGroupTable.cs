using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMMissionPassMissionGroupTable : TableBase<EntityMMissionPassMissionGroup>
    {
        private readonly Func<EntityMMissionPassMissionGroup, (int, int)> primaryIndexSelector;
        private readonly Func<EntityMMissionPassMissionGroup, int> secondaryIndexSelector;

        public EntityMMissionPassMissionGroupTable(EntityMMissionPassMissionGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.MissionPassId, element.MissionGroupId);
            secondaryIndexSelector = element => element.MissionPassId;
        }

        public RangeView<EntityMMissionPassMissionGroup> FindByMissionPassId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
    }
}
