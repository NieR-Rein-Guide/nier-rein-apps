using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserQuestTable : TableBase<EntityIUserQuest> // TypeDefIndex: 12589
    {
        // Fields
        private readonly Func<EntityIUserQuest, ValueTuple<long, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35B8DE8 Offset: 0x35B8DE8 VA: 0x35B8DE8
        public EntityIUserQuestTable(EntityIUserQuest[] sortedData):base(sortedData)
        {
            primaryIndexSelector = quest => (quest.UserId, quest.QuestId);
        }

        // RVA: 0x35B8EE8 Offset: 0x35B8EE8 VA: 0x35B8EE8
        public EntityIUserQuest FindByUserIdAndQuestId(ValueTuple<long, int> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        public bool TryFindByUserIdAndQuestId(ValueTuple<long, int> key, out EntityIUserQuest result)
        {
            result = null;

            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
