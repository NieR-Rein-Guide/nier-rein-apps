using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserEventQuestProgressStatusTable : TableBase<EntityIUserEventQuestProgressStatus> // TypeDefIndex: 12511
    {
        // Fields
        private readonly Func<EntityIUserEventQuestProgressStatus, long> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35AB5A4 Offset: 0x35AB5A4 VA: 0x35AB5A4
        public EntityIUserEventQuestProgressStatusTable(EntityIUserEventQuestProgressStatus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = status => status.UserId;
        }

        // RVA: 0x35AB6A4 Offset: 0x35AB6A4 VA: 0x35AB6A4
        public EntityIUserEventQuestProgressStatus FindByUserId(long key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
