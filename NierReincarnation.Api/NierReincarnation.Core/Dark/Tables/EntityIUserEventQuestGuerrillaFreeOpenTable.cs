using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserEventQuestGuerrillaFreeOpenTable : TableBase<EntityIUserEventQuestGuerrillaFreeOpen> // TypeDefIndex: 12769
    {
        // Fields
        private readonly Func<EntityIUserEventQuestGuerrillaFreeOpen, long> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x373E50C Offset: 0x373E50C VA: 0x373E50C
        public EntityIUserEventQuestGuerrillaFreeOpenTable(EntityIUserEventQuestGuerrillaFreeOpen[] sortedData):base(sortedData)
        {
            primaryIndexSelector = open => open.DailyOpenedCount;
        }

        public EntityIUserEventQuestGuerrillaFreeOpen FindByUserId(long key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x373E60C Offset: 0x373E60C VA: 0x373E60C
        public bool TryFindByUserId(long key, out EntityIUserEventQuestGuerrillaFreeOpen result)
        {
            result = null;

            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
