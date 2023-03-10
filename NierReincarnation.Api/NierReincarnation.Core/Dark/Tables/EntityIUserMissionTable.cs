using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserMissionTable : TableBase<EntityIUserMission>
    {
        private readonly Func<EntityIUserMission, (long, int)> primaryIndexSelector;

        public EntityIUserMissionTable(EntityIUserMission[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.MissionId);
        }

        public EntityIUserMission FindByUserIdAndMissionId(ValueTuple<long, int> key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key); }

        public bool TryFindByUserIdAndMissionId(ValueTuple<long, int> key, out EntityIUserMission result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result); }
    }
}
