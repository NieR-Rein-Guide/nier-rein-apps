using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestScheduleTable : TableBase<EntityMQuestSchedule> // TypeDefIndex: 12183
    {
        // Fields
        private readonly Func<EntityMQuestSchedule, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C57400 Offset: 0x2C57400 VA: 0x2C57400
        public EntityMQuestScheduleTable(EntityMQuestSchedule[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = schedule => schedule.QuestScheduleId;
        }

        // RVA: 0x2C57500 Offset: 0x2C57500 VA: 0x2C57500
        public EntityMQuestSchedule FindByQuestScheduleId(int key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
