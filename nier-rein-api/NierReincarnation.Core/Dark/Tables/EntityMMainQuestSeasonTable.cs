using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMMainQuestSeasonTable : TableBase<EntityMMainQuestSeason> // TypeDefIndex: 11993
    {
        // Fields
        private readonly Func<EntityMMainQuestSeason, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B49EF4 Offset: 0x2B49EF4 VA: 0x2B49EF4
        public EntityMMainQuestSeasonTable(EntityMMainQuestSeason[] sortedData):base(sortedData)
        {
            primaryIndexSelector = season => season.MainQuestSeasonId;
        }

        // RVA: 0x2B49FF4 Offset: 0x2B49FF4 VA: 0x2B49FF4
        public EntityMMainQuestSeason FindByMainQuestSeasonId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
