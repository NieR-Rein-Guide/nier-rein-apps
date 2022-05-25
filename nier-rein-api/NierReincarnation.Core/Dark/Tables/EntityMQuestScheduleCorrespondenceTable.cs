using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestScheduleCorrespondenceTable : TableBase<EntityMQuestScheduleCorrespondence> // TypeDefIndex: 12181
    {
        // Fields
        private readonly Func<EntityMQuestScheduleCorrespondence, (int, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C57224 Offset: 0x2C57224 VA: 0x2C57224
        public EntityMQuestScheduleCorrespondenceTable(EntityMQuestScheduleCorrespondence[] sortedData):base(sortedData)
        {
            primaryIndexSelector = schedule => (schedule.QuestId, schedule.QuestScheduleId);
        }
    }
}
