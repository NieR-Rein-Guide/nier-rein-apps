using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMMainQuestRouteTable : TableBase<EntityMMainQuestRoute> // TypeDefIndex: 11991
    {
        // Fields
        private readonly Func<EntityMMainQuestRoute, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B49CDC Offset: 0x2B49CDC VA: 0x2B49CDC
        public EntityMMainQuestRouteTable(EntityMMainQuestRoute[] sortedData):base(sortedData)
        {
            primaryIndexSelector = route => route.MainQuestRouteId;
        }

        // RVA: 0x2B49DDC Offset: 0x2B49DDC VA: 0x2B49DDC
        public EntityMMainQuestRoute FindByMainQuestRouteId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
