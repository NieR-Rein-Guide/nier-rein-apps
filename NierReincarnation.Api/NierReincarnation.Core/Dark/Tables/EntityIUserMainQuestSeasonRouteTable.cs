using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public sealed class EntityIUserMainQuestSeasonRouteTable : TableBase<EntityIUserMainQuestSeasonRoute> // TypeDefIndex: 12809
    {
        // Fields
        private readonly Func<EntityIUserMainQuestSeasonRoute, (long,int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x3746DC8 Offset: 0x3746DC8 VA: 0x3746DC8
        public EntityIUserMainQuestSeasonRouteTable(EntityIUserMainQuestSeasonRoute[] sortedData):base(sortedData)
        {
            primaryIndexSelector = route => (route.UserId, route.MainQuestSeasonId);
        }

        // RVA: 0x3746EC8 Offset: 0x3746EC8 VA: 0x3746EC8
        public EntityIUserMainQuestSeasonRoute FindByUserIdAndMainQuestSeasonId(ValueTuple<long, int> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
